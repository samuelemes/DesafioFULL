using App.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public class Documento : Entity
    {
        //public int? IdDocumentoOrigem { get; set; }
        [JsonIgnore]
        [ForeignKey("idDocumentoOrigem")]
        public virtual Documento DocumentoOrigem { get; set; }


        public int IdPessoa { get; set; }
        [JsonIgnore]
        [ForeignKey("IdPessoa")]
        public virtual Pessoa Pessoa { get; set; }


        public int Numero { get; set; }


        [Required]
        [Column(TypeName = "Date")]
        public DateTime DataVencimento { get; set; } = DateTime.Now;


        public decimal? Juros { get; set; } = 0;


        public decimal? Multa { get; set; } = 0;


        public int Parcela { get; set; } = 1;
    }
}
