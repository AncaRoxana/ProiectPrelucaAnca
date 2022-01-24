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

namespace ProiectPrelucaAnca.Pages.Angajati
{
    public class EditModel : PageModel
    {
        private readonly ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext _context;

        public EditModel(ProiectPrelucaAnca.Data.ProiectPrelucaAncaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat
                .Include(a => a.Departament)
                .Include(a => a.Functie)
                .Include(a => a.Localitate).FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }
           ViewData["DepartamentID"] = new SelectList(_context.Departament, "ID", "Denumire");
           ViewData["FunctieID"] = new SelectList(_context.Functie, "ID", "Denumire");
           ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "Denumire");
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

            _context.Attach(Angajat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngajatExists(Angajat.ID))
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

        private bool AngajatExists(int id)
        {
            return _context.Angajat.Any(e => e.ID == id);
        }
    }
}
