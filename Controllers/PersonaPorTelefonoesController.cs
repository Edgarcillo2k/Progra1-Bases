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
    public class PersonaPorTelefonoesController : Controller
    {
        private readonly Progra1_basesContext _context;

        public PersonaPorTelefonoesController(Progra1_basesContext context)
        {
            _context = context;
        }

        // GET: PersonaPorTelefonoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonaPorTelefono.ToListAsync());
        }

        // GET: PersonaPorTelefonoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaPorTelefono = await _context.PersonaPorTelefono
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personaPorTelefono == null)
            {
                return NotFound();
            }

            return View(personaPorTelefono);
        }

        // GET: PersonaPorTelefonoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaPorTelefonoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonaId")] PersonaPorTelefono personaPorTelefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaPorTelefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaPorTelefono);
        }

        // GET: PersonaPorTelefonoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaPorTelefono = await _context.PersonaPorTelefono.FindAsync(id);
            if (personaPorTelefono == null)
            {
                return NotFound();
            }
            return View(personaPorTelefono);
        }

        // POST: PersonaPorTelefonoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PersonaId")] PersonaPorTelefono personaPorTelefono)
        {
            if (id != personaPorTelefono.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaPorTelefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaPorTelefonoExists(personaPorTelefono.ID))
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
            return View(personaPorTelefono);
        }

        // GET: PersonaPorTelefonoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaPorTelefono = await _context.PersonaPorTelefono
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personaPorTelefono == null)
            {
                return NotFound();
            }

            return View(personaPorTelefono);
        }

        // POST: PersonaPorTelefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaPorTelefono = await _context.PersonaPorTelefono.FindAsync(id);
            _context.PersonaPorTelefono.Remove(personaPorTelefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaPorTelefonoExists(int id)
        {
            return _context.PersonaPorTelefono.Any(e => e.ID == id);
        }
    }
}
