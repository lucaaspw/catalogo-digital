using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Context;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CatalogContext _context;

        public Repository(CatalogContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
