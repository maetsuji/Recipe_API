using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string PreparationMethod { get; set; }

    public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();

    public Recipe()
    {
        Name = string.Empty; // Inicializa com um valor padrão
        PreparationMethod = string.Empty; // Inicializa com um valor padrão
        Ingredients = new List<RecipeIngredient>(); // Inicializa a lista para evitar null
    }
}

public class RecipeIngredient
{
    public int IngredientId { get; set; }
    public required Ingredient Ingredient { get; set; }

    public double Quantity { get; set; }
}