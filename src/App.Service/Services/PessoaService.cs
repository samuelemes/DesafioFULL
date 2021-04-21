﻿using App.Core.Notificador;
using App.Core.Service;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Models;
using App.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public class PessoaService : BaseService, IPessoaService
    {

        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository,
                                    INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }
        public async Task Adicionar(Pessoa model)
        {
            if (!ExecutarValidacao(new PessoaValidation(), model))
                return;

            if (await RegistroExistente(model)) return;

            await _repository.Adicionar(model);
        }

        public async Task Atualizar(Pessoa model)
        {
            if (!ExecutarValidacao(new PessoaValidation(), model))
                return;

            if (await RegistroExistente(model)) return;

            await _repository.Atualizar(model);
        }

        public async Task Remover(int id)
        {
            await _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        private async Task<bool> RegistroExistente(Pessoa model)
        {
            var item = await _repository.Buscar(f => f.Id == model.Id);

            if (!item.Any()) return false;

            Notificar("Já existe um registro cadastrado");

            return true;
        }

    }
}