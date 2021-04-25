using App.Core.Models;
using System;
using System.Threading.Tasks;

namespace App.Core.Service
{
    public interface IBaseService<T> : IDisposable where T : Entity
    {
        Task<T> Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(int id);
    }
}
