using App.Core.Repository;
using App.Data.Context;
using App.Data.Repository.Interfaces;
using App.Domain.Models;

namespace App.Data.Repository
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(AppDbContext context) : base(context) { }
    }
}
