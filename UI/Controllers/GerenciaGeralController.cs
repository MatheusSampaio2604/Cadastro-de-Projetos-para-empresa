using Application;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class GerenciaGeralController : Controller
    {
        public readonly IGerenciaGeralApp _gerenciaGeralApp;

        public GerenciaGeralController(IGerenciaGeralApp gerenciaGeralApp)
        {
            _gerenciaGeralApp = gerenciaGeralApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _gerenciaGeralApp.FindAllAsync();
            
            return View(index);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerência Geral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GerenciaGeralViewModel gerenciaGeralViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gerenciaGeralViewModel);
            }

            gerenciaGeralViewModel.Nome = gerenciaGeralViewModel.Nome.ToUpper();
            var create = await _gerenciaGeralApp.CreateAsync(gerenciaGeralViewModel);

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
            var edit = await _gerenciaGeralApp.FindOneAsync(Id);
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(GerenciaGeralViewModel gerenciaGeralViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gerenciaGeralViewModel);
            }

            gerenciaGeralViewModel.Nome = gerenciaGeralViewModel.Nome.ToUpper();
            var edit = await _gerenciaGeralApp.EditAsync(gerenciaGeralViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _gerenciaGeralApp.FindOneAsync(Id);
            return View(details);
        }
    }
}
