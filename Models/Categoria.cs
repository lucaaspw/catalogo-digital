using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<Empresa> empresas { get; set; }
    }
}
