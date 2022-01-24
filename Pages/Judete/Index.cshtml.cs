using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Judete
{
    public class IndexModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public IndexModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public IList<Judet> Judet { get;set; }
        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder,  string searchName)
        {

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";
            
            CurrentFilter = searchName;

            IQueryable<Judet> judeteSortate = from s in _context.Judet
                                              select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                judeteSortate = judeteSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "descrescator":
                    judeteSortate = judeteSortate.OrderByDescending(s => s.Denumire);
                    break;
                default:
                    judeteSortate = judeteSortate.OrderBy(s => s.Denumire);
                    break;
            }
            Judet = await judeteSortate.AsNoTracking().ToListAsync();

        }
    }
}
