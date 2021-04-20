using Paschoalotto.Core.Models;
using System;

namespace Paschoalotto.Domain.Models
{
    public class Documento : Entity
    {
        public Guid? IdDocumentoOrigem { get; set; }
        public Guid IdPessoa { get; set; }
        public int Numero { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Juros { get; set; }
        public int Parcela { get; set; } = 1;
    }
}
