using Paschoalotto.Core.Models;

namespace Paschoalotto.Domain.Models
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
