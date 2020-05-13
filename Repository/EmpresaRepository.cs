using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Context;
using Catalogo.Models;

namespace Catalogo.Repository
{
    public class EmpresaRepository : Repository<Empresa>
    {
        private readonly CatalogContext _context;
        public EmpresaRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public IList<Empresa> GetAll()
        {
            return _context.Empresa.ToList();
        }

        public void Remove(int id)
        {
            //Apagando empresa
            var empresa = _context.Empresa.Where(x => x.Id == id).FirstOrDefault();
            _context.Empresa.Remove(empresa);
            _context.SaveChanges();

        }

    }
}
