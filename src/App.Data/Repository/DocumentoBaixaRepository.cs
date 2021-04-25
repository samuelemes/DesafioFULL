using App.Core.Repository;
using App.Data.Context;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class DocumentoBaixaRepository : Repository<DocumentoBaixa>, IDocumentoBaixaRepository
    {
        public DocumentoBaixaRepository(AppDbContext context) : base(context) { }

        public async Task<List<DocumentoBaixa>> ObterBaixasDoDocumento(int idDodumento)
        {
            var list = await Db.DocumentoBaixa.Where(w => w.idDocumento == idDodumento).ToListAsync();

            return list;
        }
    }
}
