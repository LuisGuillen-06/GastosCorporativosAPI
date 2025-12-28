using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using API.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using API.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// REGISTRO DE REPOSITORIOS
// Scoped significa: "Crea uno nuevo para cada petición HTTP (cada vez que alguien entra a la web)".
// Es el ciclo de vida perfecto para bases de datos

builder.Services.AddScoped<IGastoRepository,GastoRepository>();
builder.Services.AddScoped<IEmpleadoRepository,EmpleadoRepository>();

//Activar la validación automática en los controladores
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


//Registrar todos los validadores que esten en este proyecto
builder.Services.AddValidatorsFromAssemblyContaining<GastoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EmpleadoValidator>();

builder.Services.AddControllers();

//Agregar la política de CORS (Permitir todo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   
              .AllowAnyMethod()  
              .AllowAnyHeader();  
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
app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();



app.Run();