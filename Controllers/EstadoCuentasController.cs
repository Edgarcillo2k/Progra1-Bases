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
    public class EstadoCuentasController : Controller
    {
        private readonly Progra1_basesContext _context;

        public EstadoCuentasController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: EstadoCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoCuenta.ToListAsync());
        }

        // GET: EstadoCuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCuenta = await _context.EstadoCuenta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estadoCuenta == null)
            {
                return NotFound();
            }

            return View(estadoCuenta);
        }

        // GET: EstadoCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoCuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CuentaAhorroId,FechaInicio,FechaFinalizacion,SaldoInicial,SaldoFinal,CantRetirosCajeroHumano,CantRetirosCajeroAutomatico,SaldoMinimo")] EstadoCuenta estadoCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoCuenta);
        }

        // GET: EstadoCuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCuenta = await _context.EstadoCuenta.FindAsync(id);
            if (estadoCuenta == null)
            {
                return NotFound();
            }
            return View(estadoCuenta);
        }

        // POST: EstadoCuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CuentaAhorroId,FechaInicio,FechaFinalizacion,SaldoInicial,SaldoFinal,CantRetirosCajeroHumano,CantRetirosCajeroAutomatico,SaldoMinimo")] EstadoCuenta estadoCuenta)
        {
            if (id != estadoCuenta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCuentaExists(estadoCuenta.ID))
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
            return View(estadoCuenta);
        }

        // GET: EstadoCuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCuenta = await _context.EstadoCuenta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estadoCuenta == null)
            {
                return NotFound();
            }

            return View(estadoCuenta);
        }

        // POST: EstadoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoCuenta = await _context.EstadoCuenta.FindAsync(id);
            _context.EstadoCuenta.Remove(estadoCuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoCuentaExists(int id)
        {
            return _context.EstadoCuenta.Any(e => e.ID == id);
        }
    }
}
