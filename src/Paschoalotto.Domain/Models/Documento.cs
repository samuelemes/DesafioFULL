using Paschoalotto.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Paschoalotto.Domain.Models
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
        public decimal? Multa { get; set; }
        public decimal? Juros { get; set; }
        public int Parcela { get; set; } = 1;


    }
}
