using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoAPI.Context;


var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1"
    });
});

// Adiciona o servi�o do banco de dados SQLite
builder.Services.AddDbContext<MemoryDbContext>
(options =>options.UseSqlite("Data Source=produtos.db"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();


// Ativa o Swagger na aplica��o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

// J� vem na aplica��o!!
app.Run();

