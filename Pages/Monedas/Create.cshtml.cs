using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.Monedas
{
    public class CreateModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public CreateModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Moneda Moneda { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Moneda.Add(Moneda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}