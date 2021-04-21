using App.Domain.Models;
using App.Domain.Models.Seguranca;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|DesafioFULL.mdf;Initial Catalog=DesafioFULL;Integrated Security=True; MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected void OnConfiguring(ModelBuilder optionsBuilder)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentoBaixa> DocumentoBaixa { get; set; }
    }
}
