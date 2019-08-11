using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.PersonasPorTelefono
{
    public class EditModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public EditModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonaPorTelefono PersonaPorTelefono { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonaPorTelefono = await _context.PersonaPorTelefono.FirstOrDefaultAsync(m => m.ID == id);

            if (PersonaPorTelefono == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonaPorTelefono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaPorTelefonoExists(PersonaPorTelefono.ID))
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

        private bool PersonaPorTelefonoExists(int id)
        {
            return _context.PersonaPorTelefono.Any(e => e.ID == id);
        }
    }
}
