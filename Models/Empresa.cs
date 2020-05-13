using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Número")]
        public string Number { get; set; }

        [Display(Name = "Instagram")]
        public string ProfileInstagram { get; set; }

        [Display(Name = "WhatsApp")]
        public string PhoneNumberWhatsApp { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreateDate { get; set; }

        public int CategoriaID { get; set; }

        public string Imagem { get; set; }
    }
}
