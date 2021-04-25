using App.Core.Repository.Interfaces;
using App.Domain.Models;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> ObterPessoaPorCpf(string cpf);
    }
}
