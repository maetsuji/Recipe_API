using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public string UnitOfMeasure { get; set; }

    public Ingredient()
    {
        Name = string.Empty; // Inicializa com um valor padrão
        UnitOfMeasure = string.Empty; // Inicializa com um valor padrão
    }
}

