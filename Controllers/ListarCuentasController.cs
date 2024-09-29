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

    public class ListarCuentasController : Controller
    {
        private readonly ILogger<ListarCuentasController> _logger;
        private readonly ApplicationDbContext _context;

        public ListarCuentasController(ILogger<ListarCuentasController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {

            var cuentas = _context.DataCuentaBancaria.ToList();


            var viewModel = new CuentaBancariaViewModel
            {
                ListarCuentaBancaria = cuentas 
            };

            return View(viewModel); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}