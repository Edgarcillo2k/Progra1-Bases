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
    public class TipoMovimientoesController : Controller
    {
        private readonly Progra1_basesContext _context;

        public TipoMovimientoesController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: TipoMovimientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMovimiento.ToListAsync());
        }

        // GET: TipoMovimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre")] TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento.FindAsync(id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }
            return View(tipoMovimiento);
        }

        // POST: TipoMovimientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] TipoMovimiento tipoMovimiento)
        {
            if (id != tipoMovimiento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimientoExists(tipoMovimiento.ID))
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
            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            return View(tipoMovimiento);
        }

        // POST: TipoMovimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMovimiento = await _context.TipoMovimiento.FindAsync(id);
            _context.TipoMovimiento.Remove(tipoMovimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimientoExists(int id)
        {
            return _context.TipoMovimiento.Any(e => e.ID == id);
        }
    }
}
