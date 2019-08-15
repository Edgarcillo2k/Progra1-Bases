using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;
using Progra1_bases.Models;

namespace Progra1_bases.Controllers
{
    public class CuentaAhorroesController : Controller
    {
        private readonly Progra1_basesContext _context;

        public CuentaAhorroesController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: CuentaAhorroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CuentaAhorro.ToListAsync());
        }

        // GET: CuentaAhorroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaAhorro = await _context.CuentaAhorro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuentaAhorro == null)
            {
                return NotFound();
            }

            return View(cuentaAhorro);
        }

        // GET: CuentaAhorroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuentaAhorroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Monto,FechaApertura,MonedaId,TipoCuentaId,ClienteId")] CuentaAhorro cuentaAhorro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaAhorro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuentaAhorro);
        }

        // GET: CuentaAhorroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaAhorro = await _context.CuentaAhorro.FindAsync(id);
            if (cuentaAhorro == null)
            {
                return NotFound();
            }
            return View(cuentaAhorro);
        }

        // POST: CuentaAhorroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Monto,FechaApertura,MonedaId,TipoCuentaId,ClienteId")] CuentaAhorro cuentaAhorro)
        {
            if (id != cuentaAhorro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentaAhorro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaAhorroExists(cuentaAhorro.ID))
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
            return View(cuentaAhorro);
        }

        // GET: CuentaAhorroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaAhorro = await _context.CuentaAhorro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuentaAhorro == null)
            {
                return NotFound();
            }

            return View(cuentaAhorro);
        }

        // POST: CuentaAhorroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentaAhorro = await _context.CuentaAhorro.FindAsync(id);
            _context.CuentaAhorro.Remove(cuentaAhorro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaAhorroExists(int id)
        {
            return _context.CuentaAhorro.Any(e => e.ID == id);
        }
    }
}
