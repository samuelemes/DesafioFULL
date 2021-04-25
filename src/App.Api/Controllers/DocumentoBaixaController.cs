using App.Api.ViewModels;
using App.Data.Repository.Interfaces;
using App.Domain.Models;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class DocumentoBaixaController : Controller
    {
        private readonly IDocumentoBaixaRepository _repository;
        private readonly IDocumentoBaixaService _service;
        private readonly IMapper _mapper;

        public DocumentoBaixaController(IDocumentoBaixaRepository repository,
                                    IDocumentoBaixaService service,
                                    IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }






        public async Task<ActionResult> Index()
        {
            var list = _mapper.Map<ICollection<DocumentoBaixaViewModel>>(await _repository.ObterTodos());
            
            return View(list);
        }






        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DocumentoBaixaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Adicionar(_mapper.Map<DocumentoBaixa>(model));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }







        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _repository.ObterPorId(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DocumentoBaixaViewModel>(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DocumentoBaixaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<DocumentoBaixa>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }







        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var model = await _repository.ObterPorId(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DocumentoBaixaViewModel>(model));
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
            var fornecedorViewModel = await ObterRegistro(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            await _service.Remover(id);

            return RedirectToAction("Index");
        }







        private async Task<DocumentoBaixaViewModel> ObterRegistro(int id)
        {
            return _mapper.Map<DocumentoBaixaViewModel>(await _repository.ObterPorId(id));
        }
    }
}
