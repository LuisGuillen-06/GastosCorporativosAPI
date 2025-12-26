using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// REGISTRO DE REPOSITORIOS
// Scoped significa: "Crea uno nuevo para cada petición HTTP (cada vez que alguien entra a la web)".
// Es el ciclo de vida perfecto para bases de datos

builder.Services.AddScoped<IGastoRepository,GastoRepository>();

builder.Services.AddControllers();

// PASO A: Agregar la política de CORS (Permitir todo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Acepta peticiones de cualquier web
              .AllowAnyMethod()   // Acepta GET, POST, PUT, DELETE
              .AllowAnyHeader();  // Acepta cualquier tipo de contenido
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();



app.Run();