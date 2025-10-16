using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Mappings;
using Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


// Registrar los mapeos de Mongo
OwnerMap.Configure();
PropertyMap.Configure();
PropertyImageMap.Configure();
PropertyTraceMap.Configure();

// =====================================
// 🔧 Configuración de Servicios
// =====================================

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// MongoDB Context
builder.Services.AddSingleton<MongoContext>();

// Repositorios
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
builder.Services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();

// Servicios de Aplicación
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IPropertyImageService, PropertyImageService>();
builder.Services.AddScoped<IPropertyTraceService, PropertyTraceService>();

// Controladores
builder.Services.AddControllers();


// =====================================
// 📘 Configurar Swagger / OpenAPI
// =====================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Million API",
        Version = "v1",
        Description = "API para gestión de propiedades - Sebastian Chaparro",
    });
});

// =====================================
// 🚀 Construcción de la App
// =====================================
var app = builder.Build();

// =====================================
// 🌐 Middlewares
// =====================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseCors("AllowLocalhost3000");

app.MapControllers();

app.Run();
