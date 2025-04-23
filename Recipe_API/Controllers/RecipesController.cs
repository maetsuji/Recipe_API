using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecipesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/recipes
    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
        var recipes = await _context.Recipes
            .Include(r => r.Ingredients)
            .ThenInclude(ri => ri.Ingredient)
            .ToListAsync();
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Ingredients)
            .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (recipe == null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }

    // POST: api/recipes
    [HttpPost]
    public async Task<IActionResult> PostRecipe(Recipe recipe)
    {
        
         if (await _context.Recipes.AnyAsync(r => r.Name == recipe.Name))
        {
            return BadRequest($"A recipe with the name '{recipe.Name}' already exists.");
        }
        if (string.IsNullOrWhiteSpace(recipe.Name))
        {
            return BadRequest("Recipe name cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(recipe.PreparationMethod))
        {
            return BadRequest("Preparation method cannot be empty.");
        }
        if (recipe.Ingredients == null || recipe.Ingredients.Count == 0)
        {
            return BadRequest("Recipe must have at least one ingredient.");
        }
       
        // Validate each ingredient in the recipe
        foreach (var recipeIngredient in recipe.Ingredients)
        {
            var existingIngredient = await _context.Ingredients.FindAsync(recipeIngredient.IngredientId);

            if (existingIngredient == null)
            {
                return BadRequest($"Ingredient with ID {recipeIngredient.IngredientId} does not exist.");
            }

            recipeIngredient.Ingredient = existingIngredient;
        }

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRecipes), new { id = recipe.Id }, recipe);
    }

    // PUT: api/recipes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
    {
        if (id != recipe.Id)
        {
            return BadRequest("Recipe ID in the URL does not match the ID in the payload.");
        }

        if (string.IsNullOrWhiteSpace(recipe.Name))
        {
            return BadRequest("Recipe name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(recipe.PreparationMethod))
        {
            return BadRequest("Preparation method cannot be empty.");
        }

        if (recipe.Ingredients == null || recipe.Ingredients.Count == 0)
        {
            return BadRequest("Recipe must have at least one ingredient.");
        }

        foreach (var recipeIngredient in recipe.Ingredients)
        {
            var existingIngredient = await _context.Ingredients.FindAsync(recipeIngredient.IngredientId);

            if (existingIngredient == null)
            {
                return BadRequest($"Ingredient with ID {recipeIngredient.IngredientId} does not exist.");
            }

            recipeIngredient.Ingredient = existingIngredient;
        }

        _context.Entry(recipe).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RecipeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool RecipeExists(int id)
    {
        return _context.Recipes.Any(e => e.Id == id);
    }
    // DELETE: api/recipes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (recipe == null)
        {
            return NotFound();
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}