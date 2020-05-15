using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalogo.Models;
using Catalogo.Context;
using Catalogo.Repository;

namespace Catalogo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CatalogContext _context;


        public HomeController(ILogger<HomeController> logger, CatalogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //CategoriaRepository categoria = new CategoriaRepository(_context);
            var result = _context.Categoria.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Empresas(int Id)
        {
            var categoria = _context.Categoria.Where(x => x.Id == Id).FirstOrDefault();
            List<Empresa> empresas = _context.Empresa.Where(x => x.CategoriaID == Id).OrderBy(x => x.Name).ToList();
            ViewBag.categoria = categoria.Name;
            return View(empresas);
        }

        [HttpGet]
        public IActionResult BaixarPDF(int Id)
        {
            return File("~/pdf/catalogo.pdf", "application/octet-stream");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
