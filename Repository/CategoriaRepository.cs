using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Context;
using Catalogo.Models;

namespace Catalogo.Repository
{
    public class CategoriaRepository : Repository<Categoria>
    {
        private readonly CatalogContext _context;
        public CategoriaRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public IList<Categoria> GetAll()
        {
            return _context.Categoria.ToList();
        }

        public void Update(Categoria categoria)
        {
            _context.Update<Categoria>(categoria);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            //Apagando categoria
            var categoria = _context.Categoria.Where(x => x.Id == id).FirstOrDefault();
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            //Apagando empresas da categoria
            var empresas = _context.Empresa.Where(x => x.CategoriaID == id).ToList();
            _context.Empresa.RemoveRange(empresas);
            _context.SaveChanges();

        }
    }
}
