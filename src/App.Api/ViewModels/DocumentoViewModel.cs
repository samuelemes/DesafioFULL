using System;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels
{
    public class DocumentoViewModel 
    {
        [Key]
        public int Id { get; set; }

        public int Numero { get; set; }
        public string NomeDevedor { get; set; }


        [Required]
        public DateTime DataVencimento { get; set; } = DateTime.Now;


        public decimal? Juros { get; set; } = 0;


        public decimal? Multa { get; set; } = 0;


        public int Parcela { get; set; } = 1;
        public int QtdeParcelas { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorAtualizado { get; set; }
        public int DiasEmAtrado { get; set; }
    }
}
