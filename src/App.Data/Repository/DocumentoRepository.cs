using App.Core.Repository;
using App.Data.Context;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(AppDbContext context) : base(context) { }

        public async Task<Documento> ObterDocumentoFullLoad(int id)
        {
            return await Db.Documentos.AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Documento>> ObterDocumentoEmAtraso()
        {
            var list = Db.Documentos.AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Include(i => i.Baixas)
                .ToListAsync().Result
                .Where(w => w.TipoDocumento == TipoDocumento.Titulo && w.Baixas.Count == 0 && (int)DateTime.Today.Subtract(w.DataVencimento).TotalDays > 0);

            return list.ToList();
        }
        
        public async Task<List<Documento>> ObterDocumentoAVencer()
        {
            var list = Db.Documentos.AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Include(i => i.Baixas)
                .ToListAsync().Result
                .Where(w => w.TipoDocumento == TipoDocumento.Titulo && w.Baixas.Count == 0 && (int)DateTime.Today.Subtract(w.DataVencimento).TotalDays < 0);

            return list.ToList();
        }
        public async Task<List<Documento>> ObterDocumentoPagos()
        {
            var list = Db.Documentos.AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Include(i => i.Baixas)
                .ToListAsync().Result
                .Where(w => w.TipoDocumento == TipoDocumento.Titulo && w.Baixas.Count > 0);

            return list.ToList();
        }

        public async Task<List<Documento>> ObterTitulosPorFaturaFullLoad(int idFatura)
        {
            return await Db.Documentos.AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Where(f => f.idDocumentoOrigem == idFatura)
                .ToListAsync();
        }


        public async Task<List<Documento>> ObterDocumentoFullLoad()
        {
            var list = await Db.Documentos
                .AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Where(w => w.TipoDocumento == TipoDocumento.Titulo)
                .ToListAsync();

            return list;
        }

        public async Task<List<Documento>> ObterFaturasFullLoad()
        {
            var list = await Db.Documentos
                .AsNoTracking()
                .Include(i => i.Pessoa)
                .Include(i => i.DocumentoOrigem)
                .Where(w => w.TipoDocumento == TipoDocumento.Fatura).ToListAsync();

            return list;
        }


    }
}
