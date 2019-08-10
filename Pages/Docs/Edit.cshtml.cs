using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.Docs
{
    public class EditModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public EditModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doc Doc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Doc.FirstOrDefaultAsync(m => m.ID == id);

            if (Doc == null)
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

            _context.Attach(Doc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocExists(Doc.ID))
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

        private bool DocExists(int id)
        {
            return _context.Doc.Any(e => e.ID == id);
        }
    }
}
