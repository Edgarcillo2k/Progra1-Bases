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
        public string _connectionString = "Server=tcp:serverbd01.database.windows.net,1433;Initial Catalog=bd;Persist Security Info=False;User ID=puser@serverbd01.database.windows.net;Password=Abc1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
        public IActionResult ListarEstadosCuenta()
        {
            var cliente = _context.Cliente.Include(x => x.CuentaAhorro).SingleOrDefault(i => i.ID == HttpContext.Session.GetInt32("id"));
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ConsultarEstadosCuenta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", cliente.CuentaAhorro.ID);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<EstadoCuenta> estadosCuenta = new List<EstadoCuenta>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                estadosCuenta.Add(new EstadoCuenta
                                {
                                    ID = reader.GetInt32(0),
                                    CuentaAhorroId = reader.GetInt32(1),
                                    FechaInicio = reader.GetDateTime(2),
                                    FechaFinalizacion = reader.GetDateTime(3),
                                    SaldoInicial = reader.GetDecimal(4),
                                    SaldoFinal = reader.GetDecimal(5),
                                    CantRetirosCajeroHumano = reader.GetInt32(6),
                                    CantRetirosCajeroAutomatico = reader.GetInt32(7),
                                    SaldoMinimo = reader.GetDecimal(8),
                                });
                            }
                            return View(estadosCuenta);
                        }
                    }
                }
            }
            return View();
        }
        public IActionResult ListarBeneficiarios()
        {
            var cliente = _context.Cliente.Include(x => x.CuentaAhorro).SingleOrDefault(i => i.ID == HttpContext.Session.GetInt32("id"));
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarBeneficiarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", cliente.CuentaAhorro.ID);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<Beneficiario> beneficiarios = new List<Beneficiario>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                beneficiarios.Add(new Beneficiario
                                {
                                    ID = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    FechaNacimiento = reader.GetDateTime(2),
                                    Email = reader.GetString(3),
                                    DocId = reader.GetInt32(4),
                                    Doc = reader.GetString(5),
                                    FechaDesactivacion = reader.GetDateTime(7),
                                    PorcentajeBeneficio = reader.GetInt32(8),
                                    ParentescoId = reader.GetInt32(9),
                                    Activo = reader.GetBoolean(10),
                                    CuentaAhorroId = reader.GetInt32(11)
                                });
                            }
                            return View(beneficiarios);
                        }
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> EditarBeneficiario(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarBeneficiario(int id, string Nombre, int ParentescoId, DateTime FechaNacimiento,int DocId, string Doc,string Email,int PorcentajeBeneficio)
        {
            var beneficiario = await _context.Beneficiario.FindAsync(id);
            beneficiario.Nombre = Nombre;
            beneficiario.ParentescoId = ParentescoId;
            beneficiario.FechaNacimiento = FechaNacimiento;
            beneficiario.DocId = DocId;
            beneficiario.Doc = Doc;
            beneficiario.Email = Email;
            beneficiario.PorcentajeBeneficio = PorcentajeBeneficio;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Beneficiario.Any(e => e.ID ==beneficiario.ID))
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var beneficiario = await _context.Beneficiario.FindAsync(id);
                beneficiario.Activo = false;
                beneficiario.FechaDesactivacion = DateTime.Today;
                _context.Update(beneficiario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Beneficiario.Any(e => e.ID == id))
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarBeneficiario([Bind("PorcentajeBeneficio,ParentescoId,ID,Nombre,FechaNacimiento,Email,DocId,Doc")] Beneficiario beneficiario)
        {
            var cliente = _context.Cliente.Include(x => x.CuentaAhorro).SingleOrDefault(i => i.ID == HttpContext.Session.GetInt32("id"));
            beneficiario.FechaDesactivacion = DateTime.Today;
            beneficiario.Activo = true;
            beneficiario.CuentaAhorro = cliente.CuentaAhorro;
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
                using (var con = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("dbo.LoginStoredProcedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
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