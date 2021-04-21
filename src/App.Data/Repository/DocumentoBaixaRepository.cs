using App.Core.Repository;
using App.Data.Context;
using App.Data.Repository.Interfaces;
using App.Domain.Models;

namespace App.Data.Repository
{
    public class DocumentoBaixaRepository : Repository<DocumentoBaixa>, IDocumentoBaixaRepository
    {
        public DocumentoBaixaRepository(AppDbContext context) : base(context) { }
    }
}
