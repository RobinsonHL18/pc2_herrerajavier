using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc2_herrerajavier.Data;
using pc2_herrerajavier.Models;
using pc2_herrerajavier.ViewModel;

namespace pc2_herrerajavier.Controllers
{

    public class CuentaBancariaController : Controller
    {
        private readonly ILogger<CuentaBancariaController> _logger;

        private readonly ApplicationDbContext _context;

        public CuentaBancariaController(ILogger<CuentaBancariaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cuentas = from o in _context.DataCuentaBancaria select o;
            
            var viewModel = new CuentaBancariaViewModel
            {
                FormCuentaBancaria = new CuentaBancaria(), 
                ListarCuentaBancaria = cuentas.ToList() 
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registrar(CuentaBancariaViewModel viewModel)
        {
            if (viewModel.FormCuentaBancaria.Id == 0)
            {
                _context.Add(viewModel.FormCuentaBancaria);
                TempData["Message"] = "Eres un capo gracias por tu registro.";
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}