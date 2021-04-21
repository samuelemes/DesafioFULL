using Paschoalotto.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paschoalotto.Domain.Models
{
    public class DocumentoBaixa : Entity
    {
        public int idDocumento { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDesconto { get; set; }

        [ForeignKey("idDocumento")]
        public virtual Documento Documento { get; set; }
    }
}
