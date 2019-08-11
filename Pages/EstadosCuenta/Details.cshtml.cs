using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.EstadosCuenta
{
    public class DetailsModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public DetailsModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        public EstadoCuenta EstadoCuenta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EstadoCuenta = await _context.EstadoCuenta.FirstOrDefaultAsync(m => m.ID == id);

            if (EstadoCuenta == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
