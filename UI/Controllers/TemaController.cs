using Application;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TemaController : Controller
    {
        private readonly ITemaApp _temaApp;

        public TemaController(ITemaApp temaApp)
        {
            _temaApp = temaApp;
        }


        public async Task<IActionResult> Index()
        {
            var index = await _temaApp.FindAllAsync();
            return View(index);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Tema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemaViewModel temaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(temaViewModel);
            }

            temaViewModel.Nome = temaViewModel.Nome.ToUpper();
            var create = await _temaApp.CreateAsync(temaViewModel);

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
            var edit = await _temaApp.FindOneAsync(Id);
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(TemaViewModel temaViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(temaViewModel);
            }

            temaViewModel.Nome = temaViewModel.Nome.ToUpper();
            var edit = await _temaApp.EditAsync(temaViewModel);
            if(edit is null) 
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _temaApp.FindOneAsync(Id);
            return View(details);
        }
    }

}
