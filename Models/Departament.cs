using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPrelucaAnca.Models
{
    public class Departament
    {
        public int ID { get; set; }
        [Display(Name = "Nume Departament")]
        [RegularExpression(@"^[A-Z][[A-Za-z\s\-]+$", ErrorMessage = "Numele departamentului trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 3)]
        public string Denumire { get; set; }
    }
}
