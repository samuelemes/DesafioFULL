using App.Api.ViewModels;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class DocumentosController : Controller
    {

        private readonly IDocumentoRepository _repository;
        private readonly IDocumentoService _service;
        private readonly IMapper _mapper;

        public DocumentosController(IDocumentoRepository repository,
                                    IDocumentoService service,
                                    IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }





        [HttpGet]
        public async Task<ActionResult> Faturas()
        {
            var list = await ObterFaturas();

            return View(list);
        }


        #region only Angular
            [HttpGet]
            public ICollection<DocumentoViewModel> Get()
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
        [ValidateAntiForgeryToken]
        public DocumentoViewModel Create(DocumentoViewModel model)
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
                        var fatura = _service.Adicionar(_mapper.Map<Documento>(model));
                        #endregion


                        model.idDocumentoOrigem = fatura.Id;
                        model.Valor = model.ValorOriginal;
                        model.TipoDocumento = TipoDocumentoViewModel.Titulo;

                        for (int i = 1; i < model.QtdeParcelas; i++)
                        {
                            model.Id = 0;
                            model.Parcela = i;
                            _service.Adicionar(_mapper.Map<Documento>(model));
                            model.DataVencimento = datVencimento.AddMonths(i);
                        }
                    }
                    else
                    {
                        model.Parcela = 1;
                        _service.Adicionar(_mapper.Map<Documento>(model));
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





        [HttpGet]
        public async Task<ActionResult> TituloAVencer()
        {
            var list = await _repository.ObterDocumentoAVencer();
            return View(FormatarListaDocumentos(_mapper.Map<ICollection<DocumentoViewModel>>(list)));
        }




        [HttpGet]
        public async Task<ActionResult> TituloPagos()
        {
            var list = await _repository.ObterDocumentoPagos();
            var result = new List<DocumentoViewModel>();

            foreach (var item in list)
            {
                var doc = _mapper.Map<DocumentoViewModel>(item);
                var baixa = item.Baixas.Where(s => s.idDocumento == item.Id).FirstOrDefault();

                doc.DataPagamento = baixa.DataBaixa;
                doc.ValorPago = baixa.Valor;
                doc.ValorDesconto = baixa.ValorDesconto;

                result.Add(doc);
            }

            return View(result);
        }










        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDocument(DocumentoViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(model.TipoDocumento == TipoDocumentoViewModel.Fatura)
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
                    } else
                    {
                        model.Parcela = 1;
                        await _service.Adicionar(_mapper.Map<Documento>(model));
                    }
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }







        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _repository.ObterDocumentoFullLoad(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DocumentoViewModel>(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DocumentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<Documento>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }







        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var model = await _repository.ObterDocumentoFullLoad(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DocumentoViewModel>(model));
        }






        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await ObterRegistro(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var model = await ObterRegistro(id);

            if (model == null)
            {
                return NotFound();
            }

            await _service.Remover(id);

            return RedirectToAction("Index");
        }







        private async Task<DocumentoViewModel> ObterRegistro(int id)
        {
            return _mapper.Map<DocumentoViewModel>(await _repository.ObterPorId(id));
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
                item.QtdeParcelas = item.TipoDocumento == TipoDocumentoViewModel.Fatura ? item.Parcela : item.DocumentoOrigem.Parcela;
                item.ValorAtualizado = item.Valor
                                                + (item.Multa.Value > 1 ? item.Multa.Value / 100 : item.Multa.Value)
                                                + (item.Valor * (item.Juros.Value > 1 ? item.Juros.Value / 100 : item.Juros.Value) / 30 * item.DiasEmAtrado.Value);
            }

            return documentos;
        }

    }
}
