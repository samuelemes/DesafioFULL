using App.Core.Repository.Interfaces;
using App.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IDocumentoRepository : IRepository<Documento>
    {
        Task<Documento> ObterDocumentoFullLoad(int id);
        Task<List<Documento>> ObterTitulosPorFaturaFullLoad(int idFatura);
        Task<List<Documento>> ObterDocumentoFullLoad();
        Task<List<Documento>> ObterFaturasFullLoad();
        Task<List<Documento>> ObterDocumentoEmAtraso();
        Task<List<Documento>> ObterDocumentoAVencer();
        Task<List<Documento>> ObterDocumentoPagos();
    }
}
