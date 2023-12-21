using Application;
using Application.Interfaces;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class FinanciamentoController : Controller
    {
        private readonly IFinanciamentoApp _financiamentoApp;

        public FinanciamentoController(IFinanciamentoApp financiamentoApp)
        {
            _financiamentoApp = financiamentoApp;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _financiamentoApp.FindAllAsync();
            return View(index);
        }

        // GET: Financiamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Financiamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinanciamentoViewModel financiamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(financiamentoViewModel);
            }
            financiamentoViewModel.Nome = financiamentoViewModel.Nome.ToUpper();
            var create = await _financiamentoApp.CreateAsync(financiamentoViewModel);

            if(create == null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
            
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var edit = await _financiamentoApp.FindOneAsync(Id);
            return View(edit);
        }
        //post

        [HttpPost]
        public async Task<IActionResult> Update(FinanciamentoViewModel financiamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(financiamentoViewModel);
            }

            financiamentoViewModel.Nome = financiamentoViewModel.Nome.ToUpper();
            var edit = await _financiamentoApp.EditAsync(financiamentoViewModel);
            if (edit is null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _financiamentoApp.FindOneAsync(Id);
            return View(details);
        }
    }
}
