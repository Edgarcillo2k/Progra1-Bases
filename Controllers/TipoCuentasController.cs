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
    public class TipoCuentasController : Controller
    {
        private readonly Progra1_basesContext _context;

        public TipoCuentasController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: TipoCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCuenta.ToListAsync());
        }

        // GET: TipoCuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuenta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }

            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,SaldoMinimo,MultaIncumplimientoSaldoMinimo,MontoMensualCargosServico,MaxRetirosCajeroHumano,MultaRetiroCajeroHumanoExceso,TasaInteres")] TipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuenta.FindAsync(id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }
            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,SaldoMinimo,MultaIncumplimientoSaldoMinimo,MontoMensualCargosServico,MaxRetirosCajeroHumano,MultaRetiroCajeroHumanoExceso,TasaInteres")] TipoCuenta tipoCuenta)
        {
            if (id != tipoCuenta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCuentaExists(tipoCuenta.ID))
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
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuenta = await _context.TipoCuenta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }

            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCuenta = await _context.TipoCuenta.FindAsync(id);
            _context.TipoCuenta.Remove(tipoCuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCuentaExists(int id)
        {
            return _context.TipoCuenta.Any(e => e.ID == id);
        }
    }
}
