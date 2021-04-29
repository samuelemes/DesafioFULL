using App.Api.ViewModels;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class TitulosController : Controller
    {

        private readonly IDocumentoRepository _repository;
        private readonly IDocumentoService _service;
        private readonly IMapper _mapper;

        public TitulosController(IDocumentoRepository repository,
                                    IDocumentoService service,
                                    IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }



        #region only Angular

            [HttpGet]
            public ICollection<DocumentoViewModel> GetTituloVencidos()
            {
                var list = _repository.ObterDocumentoEmAtraso();

                return FormatarListaDocumentos(_mapper.Map<ICollection<DocumentoViewModel>>(list.Result));
            }
            [HttpGet]
            public ICollection<DocumentoViewModel> GetFaturas()
            {
                var list = ObterFaturas();

                return FormatarListaDocumentos(_mapper.Map<ICollection<DocumentoViewModel>>(list.Result));
            }
            [HttpGet]
            public ICollection<DocumentoViewModel> GetDocumentosAVencer()
            {
                var list = _repository.ObterDocumentoAVencer();

                return FormatarListaDocumentos(_mapper.Map<ICollection<DocumentoViewModel>>(list.Result));
            }

            [HttpPost]
            [Route("Titulos"), ActionName("Post")]
            public async Task<DocumentoViewModel> Post([FromBody] DocumentoViewModel model)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (model.TipoDocumento == TipoDocumentoViewModel.Fatura)
                        {
                            var datVencimento = model.DataVencimento;

                            #region ADICIONAR A FATURA DE ORIGEM
                            model.ValorOriginal = model.Valor;
                            model.Valor = model.Valor * model.QtdeParcelas;
                            model.Parcela = 0;
                            model.DataVencimento = datVencimento.AddMonths(model.QtdeParcelas);
                            var fatura = await _service.Adicionar(_mapper.Map<Documento>(model));
                            #endregion


                            model.idDocumentoOrigem = fatura.Id;
                            model.Valor = model.ValorOriginal;
                            model.TipoDocumento = TipoDocumentoViewModel.Titulo;

                            for (int i = 1; i < model.QtdeParcelas; i++)
                            {
                                model.Id = 0;
                                model.Parcela = i;
                                await _service.Adicionar(_mapper.Map<Documento>(model));
                                model.DataVencimento = datVencimento.AddMonths(i);
                            }
                        }
                        else
                        {
                            model.Parcela = 1;
                            await _service.Adicionar(_mapper.Map<Documento>(model));
                        }
                        return null;
                    }

                    return model;
                }
                catch
                {
                    return null;
                }
            }
        #endregion



        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var list = await _repository.ObterDocumentoEmAtraso();

            return View(FormatarListaDocumentos(_mapper.Map<ICollection<DocumentoViewModel>>(list)));
        }


        private async Task<ICollection<DocumentoViewModel>> ObterFaturas()
        {
            var list = _mapper.Map<ICollection<DocumentoViewModel>>(await _repository.ObterFaturasFullLoad());
            /*Esta parte poderia estar dentro de uma camada tipo App.ApiService, pois, tem algumas regras que não deveriam estar diretamente na Controller*/
            return FormatarListaDocumentos(list);
        }

        private ICollection<DocumentoViewModel> FormatarListaDocumentos(ICollection<DocumentoViewModel> documentos)
        {
            foreach (var item in documentos)
            {
                item.DiasEmAtrado = (int)DateTime.Today.Subtract(item.DataVencimento).TotalDays > 0 ? (int)DateTime.Today.Subtract(item.DataVencimento).TotalDays : 0;
                item.QtdeParcelas = item.TipoDocumento == TipoDocumentoViewModel.Fatura ? item.Parcela : 1;
                item.ValorAtualizado = item.Valor
                                                + (item.Multa.Value > 1 ? item.Multa.Value / 100 : item.Multa.Value)
                                                + (item.Valor * (item.Juros.Value > 1 ? item.Juros.Value / 100 : item.Juros.Value) / 30 * item.DiasEmAtrado.Value);
            }

            return documentos;
        }

    }
}
