using App.Api.ViewModels;
using App.Data.Repository.Interfaces;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<DocumentoViewModel>>(await _repository.ObterTodos()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
