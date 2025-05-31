using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

var app = builder.Build();
app.MapControllers();
app.Run();

// testing linting actions

// yes, this is a simple API for managing recipes.
// It allows you to create, read, update, and delete recipes.
// The API uses Entity Framework Core with SQLite as the database provider.