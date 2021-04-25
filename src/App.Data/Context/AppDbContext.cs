using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Data.Context
{
    public class AppDbContext : DbContext //IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|DesafioFULL.mdf;Initial Catalog=DesafioFULL;Integrated Security=True; MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>()
                .HasOne(p => p.DocumentoOrigem).WithMany().HasForeignKey("idDocumentoOrigem");


            modelBuilder.Entity<Pessoa>().HasData(new Pessoa { Id = 1, Nome = "Samuel de Moraes Lemes", Cpf="12345678900" });
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa { Id = 2, Nome = "Jeremias de Moraes Lemes", Cpf="11111111111" });
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa { Id = 3, Nome = "Patricia de Moraes Lemes", Cpf="22222222222" });




            #region Caso de uma Fatura com 3 parcelas de 100,00 e a baixa da primeira parcela
                modelBuilder.Entity<Documento>().HasData(new Documento { Id = 1, TipoDocumento = TipoDocumento.Fatura, IdPessoa = 1, Valor = 300, Juros = new decimal(0.01), Multa = new decimal(0.02), DataVencimento = DateTime.Parse("2020-09-10"), Parcela = 10});

                modelBuilder.Entity<Documento>().HasData(new Documento { Id = 2, idDocumentoOrigem = 1, TipoDocumento = TipoDocumento.Titulo, IdPessoa = 1, Valor = 100, Juros = new decimal(0.01), Multa = new decimal(0.02), DataVencimento = DateTime.Parse("2020-07-10"), Parcela = 10});
                modelBuilder.Entity<Documento>().HasData(new Documento { Id = 3, idDocumentoOrigem = 1, TipoDocumento = TipoDocumento.Titulo, IdPessoa = 1, Valor = 100, Juros = new decimal(0.01), Multa = new decimal(0.02), DataVencimento = DateTime.Parse("2020-08-10"), Parcela = 11 });
                modelBuilder.Entity<Documento>().HasData(new Documento { Id = 4, idDocumentoOrigem = 1, TipoDocumento = TipoDocumento.Titulo, IdPessoa = 1, Valor = 100, Juros = new decimal(0.01), Multa = new decimal(0.02), DataVencimento = DateTime.Parse("2020-09-10"), Parcela = 12 });

                modelBuilder.Entity<DocumentoBaixa>().HasData(new DocumentoBaixa { Id = 4, idDocumento = 2, Valor = 100, DataBaixa = DateTime.Parse("2020-07-09"), ValorDesconto = 0 });
            #endregion






            #region Caso de uma fatura sem titulos
                modelBuilder.Entity<Documento>().HasData(new Documento { Id = 5, TipoDocumento = TipoDocumento.Fatura, IdPessoa = 2, Valor = 500, Juros = new decimal(0.01), Multa = new decimal(0.02), DataVencimento = DateTime.Parse("2020-09-10"), Parcela = 10 });
            #endregion
            
            
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
