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
    public class CuentaObjetivoesController : Controller
    {
        private readonly Progra1_basesContext _context;

        public CuentaObjetivoesController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: CuentaObjetivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CuentaObjetivo.ToListAsync());
        }

        // GET: CuentaObjetivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaObjetivo = await _context.CuentaObjetivo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuentaObjetivo == null)
            {
                return NotFound();
            }

            return View(cuentaObjetivo);
        }

        // GET: CuentaObjetivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuentaObjetivoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Saldo,FechaInicio,FechaFinalizacion,Monto,Nombre,CuentaAhorroId")] CuentaObjetivo cuentaObjetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaObjetivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuentaObjetivo);
        }

        // GET: CuentaObjetivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaObjetivo = await _context.CuentaObjetivo.FindAsync(id);
            if (cuentaObjetivo == null)
            {
                return NotFound();
            }
            return View(cuentaObjetivo);
        }

        // POST: CuentaObjetivoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Saldo,FechaInicio,FechaFinalizacion,Monto,Nombre,CuentaAhorroId")] CuentaObjetivo cuentaObjetivo)
        {
            if (id != cuentaObjetivo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentaObjetivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaObjetivoExists(cuentaObjetivo.ID))
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
            return View(cuentaObjetivo);
        }

        // GET: CuentaObjetivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaObjetivo = await _context.CuentaObjetivo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuentaObjetivo == null)
            {
                return NotFound();
            }

            return View(cuentaObjetivo);
        }

        // POST: CuentaObjetivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentaObjetivo = await _context.CuentaObjetivo.FindAsync(id);
            _context.CuentaObjetivo.Remove(cuentaObjetivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaObjetivoExists(int id)
        {
            return _context.CuentaObjetivo.Any(e => e.ID == id);
        }
    }
}
