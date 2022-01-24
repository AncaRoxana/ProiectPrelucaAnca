using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Localitati
{
    public class IndexModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public IndexModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public IList<Localitate> Localitate { get;set; }
        public string DenumireSort { get; set; }
        public string JudetSort { get; set; }
        public string CurrentFilter { get; set; }
      
        public async Task OnGetAsync(string sortOrder, string searchName)
        {
           
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "localitate_descrescator" : "";
            JudetSort = sortOrder == "judet" ? "judet_descrescator" : "judet";
            
            CurrentFilter = searchName;

            IQueryable<Localitate> localitatiSortate = from s in _context.Localitate
                                                       select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                localitatiSortate = localitatiSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "localitate_descrescator":
                    localitatiSortate = localitatiSortate.OrderByDescending(s => s.Denumire);
                    break;
                case "judet_descrescator":
                    localitatiSortate = localitatiSortate.OrderByDescending(s => s.Judet.Denumire);
                    break;
                case "judet":
                    localitatiSortate = localitatiSortate.OrderBy(s => s.Judet.Denumire);
                    break;
                default:
                    localitatiSortate = localitatiSortate.OrderBy(s => s.Denumire);
                    break;
            }
            Localitate=await localitatiSortate.AsNoTracking().Include(l => l.Judet).ToListAsync();

        }

     
       
    }
}
