using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPrelucaAnca.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [Display(Name = "Numar Contract Munca")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numarul contractului de munca trebuie sa contina doar cifre"), Required, StringLength(10, ErrorMessage = "Contractul de munca trebuie sa contina intre 1 si 10 cifre", MinimumLength = 1)]
        public string NumarCtr { get; set; }
        [RegularExpression(@"^[A-Z][[A-Za-z\s\-]+$", ErrorMessage = "Numele trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 2)]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][[A-Za-z\s\-]+$", ErrorMessage = "Prenumele trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 3)]
        public string Prenume { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAngajare { get; set; }
        [Required] 
        [Range(1500,float.MaxValue,ErrorMessage ="Salariul nu poate fi mai mic de 1500 lei!")]
        public float Salariu { get; set; }
        [Display(Name = "Localitate")]
        public int LocalitateID { get; set; }
        public Localitate Localitate { get; set; }
        [Display(Name = "Departament")]
        public int DepartamentID { get; set; }
        public Departament Departament { get; set; }
        [Display(Name = "Functie")]
        public int FunctieID { get; set; }
        public Functie Functie { get; set; }
    }
}
