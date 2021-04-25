using App.Core.Notificador;
using App.Core.Service;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Models;
using App.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public class DocumentoService : BaseService, IDocumentoService
    {

        private readonly IDocumentoRepository _repository;
        private readonly IDocumentoBaixaRepository _repositoryBaixa;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public DocumentoService(IDocumentoRepository repository,
                                IDocumentoBaixaRepository repositoryBaixa,
                                IPessoaRepository pessoaRepository,
                                IPessoaService pessoaService,
                                INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _repositoryBaixa = repositoryBaixa;
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
        }

        public async Task<Documento> Adicionar(Documento model)
        {
            model = await ObterPessoaDocumento(model);

            if (!ExecutarValidacao(new DocumentoValidation(), model) || !ExecutarValidacao(new PessoaValidation(), model.Pessoa))
                return null;

            if (await RegistroExistente(model))
                return null;

            model.Pessoa = null;

            await _repository.Adicionar(model);
            return model;
        }

        public async Task Atualizar(Documento model)
        {
            model = await ObterPessoaDocumento(model);

            if (!ExecutarValidacao(new DocumentoValidation(), model))
                return;

            var item = _repository.Buscar(w => w.Id == model.Id).Result.FirstOrDefault();
            model.idDocumentoOrigem = item.idDocumentoOrigem;
            model.TipoDocumento = item.TipoDocumento;

            await _repository.Atualizar(model);
        }

        private async Task<Documento> ObterPessoaDocumento(Documento model)
        {
            if (model.IdPessoa == 0)
            {
                var pessoa = await _pessoaRepository.ObterPessoaPorCpf(model.Pessoa.Cpf);

                if (pessoa != null)
                {
                    model.Pessoa.Id = pessoa.Id;
                }
                else
                {
                    model.Pessoa = await _pessoaService.Adicionar(model.Pessoa);
                }
                model.IdPessoa = model.Pessoa.Id;
            }

            return model;
        }

        public async Task Remover(int id)
        {
            var item = await _repository.ObterPorId(id);
            if (item == null) return;

            if (item.TipoDocumento == TipoDocumento.Fatura)
            {
                var titulos = await _repository.ObterTitulosPorFaturaFullLoad(id);
                foreach (var titulo in titulos)
                {
                    await RemoverBaixasDocumento(titulo.Id);
                    await _repository.Remover(titulo.Id);
                }
            }
            else
            {
                if (item.TipoDocumento == TipoDocumento.Titulo)
                    await RemoverBaixasDocumento(id);
            }            

            await _repository.Remover(id);
        }

        private async Task RemoverBaixasDocumento(int id)
        {
            var baixas = await _repositoryBaixa.ObterBaixasDoDocumento(id);

            foreach (var baixa in baixas)
            {
                await _repositoryBaixa.Remover(baixa.Id);
            }
        }

        private async Task<bool> RegistroExistente(Documento model)
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
