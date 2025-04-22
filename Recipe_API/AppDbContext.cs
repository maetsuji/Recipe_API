using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Additional configurations for relationships, if necessary
        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.IngredientId, ri.Quantity });
    }
}