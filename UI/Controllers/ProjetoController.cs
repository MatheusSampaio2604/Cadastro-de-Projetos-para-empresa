using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoApp _projetoApp;
        private readonly IGerenciaGeralApp _gerenciaGeralApp;
        private readonly ITemaApp _temaApp;
        private readonly IFinanciamentoApp _financiamentoApp;
        private readonly IObjetivoApp _objetivoApp;
        private readonly IUsuarioApp _usuarioApp;
        
        public ProjetoController( IUsuarioApp usuarioApp ,IProjetoApp projetoApp, ITemaApp temaApp, IFinanciamentoApp financiamentoApp, IObjetivoApp objetivoApp, IGerenciaGeralApp gerenciaGeralApp)
        {
            _gerenciaGeralApp = gerenciaGeralApp;
            _projetoApp = projetoApp;
            _temaApp = temaApp;
            _financiamentoApp = financiamentoApp;
            _objetivoApp = objetivoApp;
            _usuarioApp = usuarioApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _projetoApp.FindAllAsync();
            return View(index);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tema = await _temaApp.FindAllAsync();
            ViewBag.Objetivo = await _objetivoApp.FindAllAsync();
            ViewBag.Financiamento = await _financiamentoApp.FindAllAsync();
            ViewBag.GerenciaGeral = await _gerenciaGeralApp.FindAllAsync();
            ViewBag.Usuario = await _usuarioApp.FindAllAsync();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjetoViewModel projetoViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(projetoViewModel);
            }

            var create = await _projetoApp.CreateAsync(projetoViewModel);
           
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
            var edit = await _projetoApp.FindOneAsync(Id);
            ViewBag.Tema = await _temaApp.FindAllAsync();
            ViewBag.Objetivo = await _objetivoApp.FindAllAsync();
            ViewBag.Financiamento = await _financiamentoApp.FindAllAsync();
            ViewBag.GerenciaGeral = await _gerenciaGeralApp.FindAllAsync();
            ViewBag.Usuario = await _usuarioApp.FindAllAsync();
            
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(ProjetoViewModel projetoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(projetoViewModel);
            }

            if (projetoViewModel.ApoioId.Contains(projetoViewModel.ResponsavelId) || projetoViewModel.ApoioId.Contains(projetoViewModel.ClienteId))
            {
                string script = "alert('Não é possivel fazer isso')";
                
                return View(projetoViewModel);
            }

            var edit = await _projetoApp.EditAsync(projetoViewModel);
            
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _projetoApp.FindOneAsync(Id);
            return View(details);
        }

    }
}
