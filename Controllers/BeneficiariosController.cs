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
    public class BeneficiariosController : Controller
    {
        private readonly Progra1_basesContext _context;

        public BeneficiariosController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: Beneficiarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beneficiario.ToListAsync());
        }

        // GET: Beneficiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // GET: Beneficiarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficiarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaDesactivacion,PorcentajeBeneficio,ParentescoId,Activo,CuentaAhorroId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiario);
        }

        // GET: Beneficiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiario.FindAsync(id);
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        // POST: Beneficiarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaDesactivacion,PorcentajeBeneficio,ParentescoId,Activo,CuentaAhorroId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            if (id != beneficiario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiarioExists(beneficiario.ID))
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
            return View(beneficiario);
        }

        // GET: Beneficiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // POST: Beneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiario = await _context.Beneficiario.FindAsync(id);
            _context.Beneficiario.Remove(beneficiario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiarioExists(int id)
        {
            return _context.Beneficiario.Any(e => e.ID == id);
        }
    }
}
