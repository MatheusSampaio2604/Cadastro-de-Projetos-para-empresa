using Application;
using Application.Interfaces;
using Application.ViewModel;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class GerenciaController : Controller
    {
        private readonly IGerenciaApp _gerenciaApp;
        private readonly IGerenciaRepository _gerenciaRepository;
        private readonly IGerenciaGeralApp _gerenciaGeralApp;
        private readonly DataContext _dataContext;
        public GerenciaController(IGerenciaApp gerenciaApp, IGerenciaGeralApp gerenciaGeralApp, DataContext dataContext, IGerenciaRepository gerenciaRepository)
        {
            _gerenciaApp = gerenciaApp;
            _gerenciaGeralApp = gerenciaGeralApp;
            _dataContext = dataContext;
            _gerenciaRepository = gerenciaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _gerenciaApp.FindAllAsync();
            return View(index);
        }

        // GET: Financiamento/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.GerenciaGeral = await _gerenciaGeralApp.FindAllAsync();
            return View();
        }

        // POST: Gerência/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GerenciaViewModel gerenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gerenciaViewModel);
            }

            gerenciaViewModel.Nome = gerenciaViewModel.Nome.ToUpper();
            var create = await _gerenciaApp.CreateAsync(gerenciaViewModel);
            
            if (create == null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));

        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var edit = await _gerenciaApp.FindOneAsync(Id);
            ViewBag.GerenciaGeral = await _gerenciaGeralApp.FindAllAsync();
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(GerenciaViewModel gerenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gerenciaViewModel);
            }

            gerenciaViewModel.Nome = gerenciaViewModel.Nome.ToUpper();
            var edit = await _gerenciaApp.EditAsync(gerenciaViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _gerenciaApp.FindOneAsync(Id);
            return View(details);
        }



    }
}
