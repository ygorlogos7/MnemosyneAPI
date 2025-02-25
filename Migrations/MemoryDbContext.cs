using Microsoft.EntityFrameworkCore;
using MnemosyneAPI.Model;
namespace ProjetoAPI.Context
{
    public class MemoryDbContext : DbContext
        {
            public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
            {
            }

            // Define a tabela 'Produtos' no banco de dados
            public DbSet<Memory> Produtos => Set<Memory>();
        }
    }


