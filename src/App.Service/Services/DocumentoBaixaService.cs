using App.Core.Notificador;
using App.Core.Service;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Models;
using App.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public class DocumentoBaixaService : BaseService, IDocumentoBaixaService
    {

        private readonly IDocumentoBaixaRepository _repository;

        public DocumentoBaixaService(IDocumentoBaixaRepository repository,
                                    INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }
        public async Task<DocumentoBaixa> Adicionar(DocumentoBaixa model)
        {
            if (!ExecutarValidacao(new DocumentoBaixaValidation(), model))
                return null;

            if (await RegistroExistente(model)) 
                return null;

            await _repository.Adicionar(model);
            return model;
        }

        public async Task Atualizar(DocumentoBaixa model)
        {
            if (!ExecutarValidacao(new DocumentoBaixaValidation(), model))
                return;

            if (await RegistroExistente(model)) return;

            await _repository.Atualizar(model);
        }

        public async Task Remover(int id)
        {
            await _repository.Remover(id);
        }
        
        private async Task<bool> RegistroExistente(DocumentoBaixa model)
        {
            var item = await _repository.Buscar(f => f.Id == model.Id);

            if (!item.Any()) return false;

            Notificar("Já existe um registro cadastrado");

            return true;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
