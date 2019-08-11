using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.PersonasPorTelefono
{
    public class DeleteModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public DeleteModel(Progra1_Bases.Models.Progra1_BasesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonaPorTelefono = await _context.PersonaPorTelefono.FindAsync(id);

            if (PersonaPorTelefono != null)
            {
                _context.PersonaPorTelefono.Remove(PersonaPorTelefono);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
