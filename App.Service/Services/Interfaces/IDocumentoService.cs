using App.Core.Service;
using App.Domain.Models;
using System;

namespace App.Service.Services.Interfaces
{
    public interface IDocumentoService : IBaseService<Documento>, IDisposable
    {
    }
}
