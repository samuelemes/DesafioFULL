using App.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    public class Documento : Entity
    {
        public Documento()
        {
            Baixas = new List<DocumentoBaixa>();
        }
        [ForeignKey("idDocumentoOrigem")]
        public int? idDocumentoOrigem { get; set; }
        public virtual Documento DocumentoOrigem { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }


        public int IdPessoa { get; set; }
        [ForeignKey("IdPessoa")]
        public virtual Pessoa Pessoa { get; set; }


        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; } = DateTime.Now;


        public decimal? Juros { get; set; } = 0;
        public decimal Valor { get; set; }


        public decimal? Multa { get; set; } = 0;


        public int Parcela { get; set; } = 1;


        public List<DocumentoBaixa> Baixas { get; set; }
    }
}
