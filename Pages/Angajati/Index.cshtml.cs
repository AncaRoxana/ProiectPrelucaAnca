using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public IndexModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }
        public string NumeSort { get; set; }
        public string PrenumeSort { get; set; }
        public string FunctieSort { get; set; }
        public string SalariuSort { get; set; }
        public string DepartamentSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder,  string searchName)
        {

            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_descrescator" : "";
            PrenumeSort = sortOrder == "prenume" ? "prenume_descrescator" : "prenume";
            FunctieSort = sortOrder == "functie" ? "functie_descrescator" : "functie";
            SalariuSort = sortOrder == "salariu" ? "salariu_descrescator" : "salariu";
            DepartamentSort = sortOrder == "departament" ? "departament_descrescator" : "departament";

            CurrentFilter = searchName;

            IQueryable<Angajat> angajatiSortati = from s in _context.Angajat
                                                       select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                angajatiSortati = angajatiSortati.Where(s => s.Nume.Contains(searchName) || s.Prenume.Contains(searchName) || s.Functie.Denumire.Contains(searchName)|| s.Salariu.ToString().Contains(searchName));
            }

            switch (sortOrder)
            {
                case "nume_descrescator":
                    angajatiSortati = angajatiSortati.OrderByDescending(s => s.Nume);
                    break;
                case "prenume_descrescator":
                    angajatiSortati = angajatiSortati.OrderByDescending(s => s.Prenume);
                    break;
                case "prenume":
                    angajatiSortati = angajatiSortati.OrderBy(s => s.Prenume);
                    break;
                case "functie_descrescator":
                    angajatiSortati = angajatiSortati.OrderByDescending(s => s.Functie.Denumire);
                    break;
                case "functie":
                    angajatiSortati = angajatiSortati.OrderBy(s => s.Functie.Denumire);
                    break;
                case "salariu":
                    angajatiSortati = angajatiSortati.OrderBy(s => s.Salariu);
                    break;
                case "salariu_descrescator":
                    angajatiSortati = angajatiSortati.OrderByDescending(s => s.Salariu);
                    break;
                case "departament":
                    angajatiSortati = angajatiSortati.OrderBy(s => s.Departament.Denumire);
                    break;
                case "departament_descrescator":
                    angajatiSortati = angajatiSortati.OrderByDescending(s => s.Departament.Denumire);
                    break;
                default:
                    angajatiSortati = angajatiSortati.OrderBy(s => s.Nume);
                    break;

            }
            Angajat = await angajatiSortati.AsNoTracking().Include(a => a.Departament)
                .Include(a => a.Functie)
                .Include(a => a.Localitate).ToListAsync();

        }

       
    }
}
