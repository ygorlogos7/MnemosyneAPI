using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MnemosyneAPI.Endpoints;
using MnemosyneAPI.Model.Validates;
using ProjetoAPI.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<MemoryValidator>();

// Adiciona o serviço do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mnemosyne API",
        Version = "v1",
        Description = "API  desenvolvida no curso de Programaçao em C#, para atender ao Frotend do site Mnemosyne"
        
    });
});

// Adiciona o serviço do banco de dados SQLite
builder.Services.AddDbContext<MemoryDbContext>
(options =>options.UseSqlite("Data Source=memories.db"));

var app = builder.Build();

// Ativa o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mnemosyne API v1");
    });
}

app.MapMemoryEndpoints();

// Já vem na aplicação!!
app.Run();

