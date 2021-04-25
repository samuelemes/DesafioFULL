using App.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    public class DocumentoBaixa : Entity
    {
        public int idDocumento { get; set; }

        public DateTimeOffset DataBaixa { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorDesconto { get; set; }

        [ForeignKey("idDocumento")]
        public virtual Documento Documento { get; set; }
    }
}
