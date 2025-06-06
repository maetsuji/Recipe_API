using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public string? PreparationMethod { get; set; }

    public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();

}

public class RecipeIngredient
{
    public int RecipeId { get; set; } // Add this property
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
    public double Quantity { get; set; }
}