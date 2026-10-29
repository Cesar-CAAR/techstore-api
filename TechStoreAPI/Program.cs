using Microsoft.EntityFrameworkCore;
using TechStoreAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 1. AGREGAR SERVICIOS DE SWAGGER (Generan la documentación de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext con PostgreSQL leyendo el appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NeonDB")));

// Habilitar CORS para permitir peticiones del frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 2. HABILITAR SWAGGER SIEMPRE (Sin el "if (IsDevelopment())" para que funcione en Render)
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();