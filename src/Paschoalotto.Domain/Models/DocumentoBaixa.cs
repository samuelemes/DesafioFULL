using Paschoalotto.Core.Models;
using System;

namespace Paschoalotto.Domain.Models
{
    public class DocumentoBaixa : Entity
    {
        public Guid idDocumento { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}
