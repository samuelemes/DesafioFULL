using App.Core.Repository;
using App.Data.Context;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext context) : base(context) { }

        public async Task<Pessoa> ObterPessoaPorCpf(string cpf)
        {
            return await Db.Pessoas.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Cpf == cpf);
        }
    }
}
