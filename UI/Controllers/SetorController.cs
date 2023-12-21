using Application;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class SetorController : Controller
    {
        private readonly ISetorApp _setorApp;

        public SetorController(ISetorApp setorApp)
        {
            _setorApp = setorApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _setorApp.FindAllAsync();
            return View(index);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Financiamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SetorViewModel setorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(setorViewModel);
            }

            setorViewModel.Nome = setorViewModel.Nome.ToUpper();
            var create = await _setorApp.CreateAsync(setorViewModel);

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
            var edit = await _setorApp.FindOneAsync(Id);
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(SetorViewModel setorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(setorViewModel);
            }

            setorViewModel.Nome = setorViewModel.Nome.ToUpper();
            var edit = await _setorApp.EditAsync(setorViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _setorApp.FindOneAsync(Id);
            return View(details);
        }
    }
}
