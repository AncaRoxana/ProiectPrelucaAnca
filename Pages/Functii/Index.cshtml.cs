using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Functii
{
    public class IndexModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public IndexModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public IList<Functie> Functie { get;set; }
        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchName)
        {

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";

            CurrentFilter = searchName;

            IQueryable<Functie> FunctiiSortate = from s in _context.Functie
                                              select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                FunctiiSortate = FunctiiSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "descrescator":
                    FunctiiSortate = FunctiiSortate.OrderByDescending(s => s.Denumire);
                    break;
                default:
                    FunctiiSortate = FunctiiSortate.OrderBy(s => s.Denumire);
                    break;
            }
            Functie = await FunctiiSortate.AsNoTracking().ToListAsync();

        }
    }
}
