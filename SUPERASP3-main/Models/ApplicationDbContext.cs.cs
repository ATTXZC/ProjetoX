using Microsoft.EntityFrameworkCore;

namespace Eco_life.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cadastros1> Cadastros1 { get; set; }
        public DbSet<Produtos1> Produtos1 { get; set; }
        public DbSet<Funcionario1> Funcionarios1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastros1>().HasKey(u => u.ID_User);
            modelBuilder.Entity<Produtos1>().HasKey(p => p.ID_Produtos);
            modelBuilder.Entity<Funcionario1>().HasKey(f => f.Id_Funcionario);
        }
    }
}