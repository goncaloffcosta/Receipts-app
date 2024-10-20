using Microsoft.EntityFrameworkCore;
using Receitas.Models;

namespace Receitas.Data
{
    public class ReceitasContext : DbContext
    {
        public ReceitasContext(DbContextOptions<ReceitasContext> options) : base(options)
        {
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar precisões de decimal, se necessário
            modelBuilder.Entity<ReceitaIngrediente>()
                .Property(ri => ri.Quantidade)
                .HasColumnType("decimal(18,2)");
        }
    }
}
