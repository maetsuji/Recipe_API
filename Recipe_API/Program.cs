using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

var app = builder.Build();
app.MapControllers();
app.Run();

// my recipe API
// This is a simple API for managing recipes.
// It allows you to create, read, update, and delete recipes.
// The API uses Entity Framework Core with SQLite for data storage.