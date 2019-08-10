using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.Docs
{
    public class DeleteModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public DeleteModel(Progra1_Bases.Models.Progra1_BasesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Doc.FindAsync(id);

            if (Doc != null)
            {
                _context.Doc.Remove(Doc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
