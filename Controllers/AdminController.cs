using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Context;
using Catalogo.Models;
using Catalogo.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class AdminController : Controller
    {
        private readonly CatalogContext _context;
        private readonly IHostingEnvironment _host;

        public AdminController(CatalogContext context, IHostingEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllCatalogs()
        {
            var result = _context.Categoria.OrderByDescending(x => x.Id).ToList();
            return View(result);            
        }

        [HttpGet]
        public ActionResult DeleteCategoria(int Id)
        {
            CategoriaRepository categoria = new CategoriaRepository(_context);
            categoria.Remove(Id);
            return RedirectToAction("ViewAllCatalogs","Admin");
        }

        [HttpGet]
        public ActionResult DeleteEmpresa(int Id)
        {
            Empresa empresa = _context.Empresa.Where(x => x.Id == Id).FirstOrDefault();

            EmpresaRepository empresaRepository = new EmpresaRepository(_context);
            empresaRepository.Remove(Id);

            return RedirectToAction("ViewCategoria", "Admin", new { Id = empresa.CategoriaID });
        }

        [HttpPost]
        public ActionResult AddCategoria(Categoria categoria)
        {
            categoria.CreateDate = DateTime.Now;
            CategoriaRepository categoriarepository = new CategoriaRepository(_context);
            categoriarepository.Add(categoria);

            return RedirectToAction("ViewAllCatalogs", "Admin");
        }   

        [HttpGet]
        public ActionResult ViewCategoria(int Id)
        {
            var empresas = _context.Empresa.Where(x => x.CategoriaID == Id).ToList();
            var categoria = _context.Categoria.Where(x => x.Id == Id).FirstOrDefault();

            ViewBag.Categoria = categoria.Name;
            ViewBag.CategoriaId = Id;

            return View(empresas);
        }

        [HttpPost]
        public ActionResult AddEmpresa(Empresa empresa, IFormFile file)
        {
            Guid archive = Guid.NewGuid();

            if (file?.Length > 0)
            {
                var wwwroot = _host.WebRootPath;

                var filePath = wwwroot + "/icones/" + archive.ToString() + file.FileName;
                empresa.Imagem = archive.ToString() + file.FileName;

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
            }
            
            empresa.CreateDate = DateTime.Now;
            EmpresaRepository empresarepository = new EmpresaRepository(_context);
            empresarepository.Add(empresa);
            return RedirectToAction("ViewCategoria", "Admin", new { Id = empresa.CategoriaID });
        }
    }
}