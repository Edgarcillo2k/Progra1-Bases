using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.TiposCuenta
{
    public class IndexModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public IndexModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        public IList<TipoCuenta> TipoCuenta { get;set; }

        public async Task OnGetAsync()
        {
            TipoCuenta = await _context.TipoCuenta.ToListAsync();
        }
    }
}
