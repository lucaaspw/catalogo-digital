using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Empresa>().Property(b=> b.Name).IsRequired();
        }
    }
}
