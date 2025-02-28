using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MnemosyneAPI.Endpoints;
using MnemosyneAPI.Model.Validates;
using ProjetoAPI.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var MinhasOrigens = "_minhasorigens";

builder.Services.AddCors(
    options => {
        options.AddPolicy(
        name: MinhasOrigens,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
    }    
);

builder.Services.AddValidatorsFromAssemblyContaining<MemoryValidator>();

// Adiciona o servi�o do Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = " API Mnemosyne ",
        Version = "v1",
        Description = "API  desenvolvida no curso de Programa�ao em C#, para atender ao Frotend do site Mnemosyne"
    });
});

// Adiciona o servi�o do banco de dados SQLite
builder.Services.AddDbContext<MemoryDbContext>

(options =>options.UseSqlite("Data Source=memories.db"));
    
var app = builder.Build();

// Ativa o Swagger na aplica��o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mnemosyne API v1");
    });
}

app.MapMemoryEndpoints();

app.UseCors(MinhasOrigens);

// J� vem na aplica��o!!
app.Run();

