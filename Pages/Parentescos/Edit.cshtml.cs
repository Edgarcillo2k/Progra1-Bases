﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_Bases.Pages.Parentescos
{
    public class EditModel : PageModel
    {
        private readonly Progra1_Bases.Models.Progra1_BasesContext _context;

        public EditModel(Progra1_Bases.Models.Progra1_BasesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parentesco Parentesco { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parentesco = await _context.Parentesco.FirstOrDefaultAsync(m => m.ID == id);

            if (Parentesco == null)
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

            _context.Attach(Parentesco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentescoExists(Parentesco.ID))
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

        private bool ParentescoExists(int id)
        {
            return _context.Parentesco.Any(e => e.ID == id);
        }
    }
}
