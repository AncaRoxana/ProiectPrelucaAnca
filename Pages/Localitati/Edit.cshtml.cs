using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Data;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Pages.Localitati
{
    public class EditModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public EditModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Denumire");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Localitate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalitateExists(Localitate.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LocalitateExists(int id)
        {
            return _context.Localitate.Any(e => e.ID == id);
        }
    }
}
