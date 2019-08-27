using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Progra1_bases.Models;
using Microsoft.EntityFrameworkCore;

namespace Progra1_bases.Controllers
{
    public class AccountController : Controller
    {
        private readonly Progra1_basesContext _context;
        public AccountController(Progra1_basesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                return View("Success");
            }
            return View();
        }

        public IActionResult AgregarBeneficiario()
        {
            return View();
        }

        public IActionResult ListarBeneficiarios()
        {
            var beneficiarios = from b in _context.Beneficiario
                           select b;
            beneficiarios = beneficiarios.Where(s => s.CuentaAhorroId == HttpContext.Session.GetInt32("id"));
            return View(beneficiarios);
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarBeneficiario([Bind("PorcentajeBeneficio,ParentescoId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            var cliente = await _context.Cliente.FindAsync(HttpContext.Session.GetInt32("id"));
            beneficiario.CuentaAhorroId = cliente.CuentaAhorro.ID;
            beneficiario.FechaDesactivacion = DateTime.Today;
            beneficiario.Activo = true;
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiario);
        }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarBeneficiario([Bind("FechaDesactivacion,PorcentajeBeneficio,ParentescoId,Activo,CuentaAhorroId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiario);
        }
        public IActionResult Login(string Username, string Password)
        {
            var clientes = from c in _context.Cliente
                         select c;

            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                clientes = clientes.Where(s => s.Username.Equals(Username) && s.Password.Equals(Password));
                if (clientes.Count() > 0)
                {
                    HttpContext.Session.SetInt32("id", clientes.First().ID);
                    return View("Success");
                }
                else
                {
                    ViewBag.error = "Cuenta invalida";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.error = "Cuenta invalida";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index");
        }
    }
}