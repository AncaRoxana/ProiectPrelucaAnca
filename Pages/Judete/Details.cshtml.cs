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
    public class DetailsModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public DetailsModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        public Judet Judet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Judet = await _context.Judet.FirstOrDefaultAsync(m => m.ID == id);

            if (Judet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
