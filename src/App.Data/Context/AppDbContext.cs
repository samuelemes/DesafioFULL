using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paschoalotto.Domain.Models;
using Paschoalotto.Domain.Models.Seguranca;
using System.Linq;

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
            foreach (var item in optionsBuilder.Model.GetEntityTypes())
            {
                var properties = item.GetProperties().Where(p => p.ClrType == typeof(string));
                foreach (var prop in properties)
                {
                    if (string.IsNullOrEmpty(prop.GetColumnType()))
                    {
                        prop.SetMaxLength(100);
                        prop.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentoBaixa> DocumentoBaixa { get; set; }
    }
}
