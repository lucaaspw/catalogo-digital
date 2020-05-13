using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Repository
{
    public interface IRepository<TEntity>
    {
         void Add(TEntity entity);

         void Remove(int Id);
    }
}
