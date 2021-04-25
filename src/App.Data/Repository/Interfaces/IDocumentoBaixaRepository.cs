using App.Core.Repository.Interfaces;
using App.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IDocumentoBaixaRepository : IRepository<DocumentoBaixa>
    {
        Task<List<DocumentoBaixa>> ObterBaixasDoDocumento(int id);
    }
}
