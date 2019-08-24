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
            if(HttpContext.Session.GetString("username") != null)
            {
                return View("Success");
            }
            return View("Success");
        }

        public IActionResult AgregarBeneficiario()
        {
            return View("agregarBeneficiario");
        }

        public IActionResult ListarBeneficiarios()
        {
            return View("indexBeneficiarios");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PorcentajeBeneficio,ParentescoId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
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
        public IActionResult Login(string Username, string Password)
        {
            //if (_context.Cliente.Any(e => e.Username == username) && _context.Cliente.Any(e => e.Password == password)) esto es mas rapido
            //pero no se como hacer que revise en el mismo elemento si la contrasenia coincide
            var clientes = from c in _context.Cliente
                         select c;

            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                clientes = clientes.Where(s => s.Username.Equals(Username) && s.Password.Equals(Password));
                if (clientes.Count() > 0)
                {
                    HttpContext.Session.SetInt32("id", clientes.ElementAt(0).ID);
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