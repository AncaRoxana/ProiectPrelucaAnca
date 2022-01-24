using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPrelucaAnca.Models
{
    public class Judet
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][[A-Za-z\s\-]+$", ErrorMessage = "Numele judetului trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 3)]
        [Display(Name="Nume Judet")]
        public string Denumire { get; set; }
    }
}
