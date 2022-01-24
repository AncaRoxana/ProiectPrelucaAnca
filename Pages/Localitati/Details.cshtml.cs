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
    public class DetailsModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public DetailsModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public Localitate Localitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Localitate = await _context.Localitate
                .Include(l => l.Judet).FirstOrDefaultAsync(m => m.ID == id);

            if (Localitate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
