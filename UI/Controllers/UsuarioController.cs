using Application;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly ISetorApp _setorApp;
        private readonly IGerenciaApp _gerenciaApp;

        public UsuarioController(IUsuarioApp usuarioApp, ISetorApp setorApp, IGerenciaApp gerenciaApp)
        {
            _usuarioApp = usuarioApp;
            _setorApp = setorApp;
            _gerenciaApp = gerenciaApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _usuarioApp.FindAllAsync();
            return View(index);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Setor = await _setorApp.FindAllAsync();
            ViewBag.Gerencia = await _gerenciaApp.FindAllAsync();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioViewModel);
            }

            usuarioViewModel.Nome = usuarioViewModel.Nome.ToUpper();
            var create = await _usuarioApp.CreateAsync(usuarioViewModel);

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
            var edit = await _usuarioApp.FindOneAsync(Id);
            ViewBag.Setor = await _setorApp.FindAllAsync();
            ViewBag.Gerencia = await _gerenciaApp.FindAllAsync();
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioViewModel);
            }

            usuarioViewModel.Nome = usuarioViewModel.Nome.ToUpper();
            var edit = await _usuarioApp.EditAsync(usuarioViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _usuarioApp.FindOneAsync(Id);
            return View(details);
        }

    }
}
