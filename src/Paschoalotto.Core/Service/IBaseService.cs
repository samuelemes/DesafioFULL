using Paschoalotto.Core.Models;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Core.Service
{
    public interface IBaseService<T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid id);
    }
}
