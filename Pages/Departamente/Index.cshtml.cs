using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Departamente
{
    public class IndexModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public IndexModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; }

        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchName)
        {

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";

            CurrentFilter = searchName;

            IQueryable<Departament> DepartamenteSortate = from s in _context.Departament
                                                 select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                DepartamenteSortate = DepartamenteSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "descrescator":
                    DepartamenteSortate = DepartamenteSortate.OrderByDescending(s => s.Denumire);
                    break;
                default:
                    DepartamenteSortate = DepartamenteSortate.OrderBy(s => s.Denumire);
                    break;
            }
            Departament = await DepartamenteSortate.AsNoTracking().ToListAsync();

        }
    }
}
