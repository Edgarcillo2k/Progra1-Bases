using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progra1_bases.Models;

namespace Progra1_bases.Controllers
{
    public class ParentescoesController : Controller
    {
        private readonly Progra1_basesContext _context;

        public ParentescoesController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: Parentescoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parentesco.ToListAsync());
        }

        // GET: Parentescoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentesco = await _context.Parentesco
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parentesco == null)
            {
                return NotFound();
            }

            return View(parentesco);
        }

        // GET: Parentescoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parentescoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre")] Parentesco parentesco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentesco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentesco);
        }

        // GET: Parentescoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentesco = await _context.Parentesco.FindAsync(id);
            if (parentesco == null)
            {
                return NotFound();
            }
            return View(parentesco);
        }

        // POST: Parentescoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] Parentesco parentesco)
        {
            if (id != parentesco.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentesco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentescoExists(parentesco.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parentesco);
        }

        // GET: Parentescoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentesco = await _context.Parentesco
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parentesco == null)
            {
                return NotFound();
            }

            return View(parentesco);
        }

        // POST: Parentescoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentesco = await _context.Parentesco.FindAsync(id);
            _context.Parentesco.Remove(parentesco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentescoExists(int id)
        {
            return _context.Parentesco.Any(e => e.ID == id);
        }
    }
}
