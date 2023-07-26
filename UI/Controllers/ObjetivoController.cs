using Application;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly IObjetivoApp _objetivoApp;

        public ObjetivoController(IObjetivoApp objetivoApp)
        {
            _objetivoApp = objetivoApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _objetivoApp.FindAllAsync();
            return View(index);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Objetivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObjetivoViewModel objetivoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(objetivoViewModel);
            }

            objetivoViewModel.Nome = objetivoViewModel.Nome.ToUpper();
            var create = await _objetivoApp.CreateAsync(objetivoViewModel);

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
            var edit = await _objetivoApp.FindOneAsync(Id);
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(ObjetivoViewModel objetivoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(objetivoViewModel);
            }

            objetivoViewModel.Nome = objetivoViewModel.Nome.ToUpper();
            var edit = await _objetivoApp.EditAsync(objetivoViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _objetivoApp.FindOneAsync(Id);
            return View(details);
        }

    }
}
