using ClasstermindS.Application.Interfaces;
using ClasstermindS.Application.Services;
using ClasstermindS.Infrastructure.Interfaces;
using ClasstermindS.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using ClasstermindS.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClasstermindS API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNameCaseInsensitive = true,
    TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
        Modifiers =
        {
            typeInfo =>
            {
                if (typeInfo.Type == typeof(BaseSubject))
                {
                    typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                    {
                        TypeDiscriminatorPropertyName = "$type",
                        DerivedTypes =
                        {
                            new JsonDerivedType(typeof(ExternalSubject), "external"),
                            new JsonDerivedType(typeof(PredefinedSubject), "predefined")

                        }
                    };
                }
            }
        }
    }
};

builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISubjectRepository>(provider =>
    new SubjectRepository("subjects.json", options));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClasstermindS API v1"));
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
