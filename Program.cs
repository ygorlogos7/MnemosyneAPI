using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoAPI.Context;


var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1"
    });
});

// Adiciona o serviço do banco de dados SQLite
builder.Services.AddDbContext<MemoryDbContext>
(options =>options.UseSqlite("Data Source=produtos.db"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();


// Ativa o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

// Já vem na aplicação!!
app.Run();

