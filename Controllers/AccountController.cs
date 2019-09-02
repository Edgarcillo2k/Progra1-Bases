using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Progra1_bases.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

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
            var cliente = _context.Cliente.Include(x => x.CuentaAhorro).SingleOrDefault(i => i.ID == HttpContext.Session.GetInt32("id"));
            beneficiarios = beneficiarios.Where(s => s.CuentaAhorroId == cliente.CuentaAhorro.ID);
            return View(beneficiarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarBeneficiario([Bind("PorcentajeBeneficio,ParentescoId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            var cliente = _context.Cliente.Include(x => x.CuentaAhorro).SingleOrDefault(i => i.ID == HttpContext.Session.GetInt32("id"));
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
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                //todo esto es necesario para el sp
                string _connectionString = "Server=tcp:serverbd01.database.windows.net,1433;Initial Catalog=bd;Persist Security Info=False;User ID=puser@serverbd01.database.windows.net;Password=Abc1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (var con = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("dbo.LoginStoredProcedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            //si entra al if es porque encontro el dato buscado
                            if (reader.Read())
                            {
                                HttpContext.Session.SetInt32("id", reader.GetInt32(0));
                                return View("Success");
                            }
                            ViewBag.error = "Cuenta invalida";
                            return View("Index");
                        }
                    }
                }
                //hasta aqui
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