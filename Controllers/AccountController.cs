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
        public IActionResult AgregarTelefono(int? id)
        {
            return View();
        }
        public IActionResult ListarEstadosCuenta()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ConsultarEstadosCuenta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", HttpContext.Session.GetInt32("id"));
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
            ViewBag.error = "Error: No hay ningun estado de cuenta";
            return View("Success");
        }
        public IActionResult ListarBeneficiarios()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarBeneficiarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", HttpContext.Session.GetInt32("id"));
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
                                    FechaDesactivacion = reader.GetDateTime(6),
                                    PorcentajeBeneficio = reader.GetInt32(7),
                                    ParentescoId = reader.GetInt32(8),
                                    Activo = reader.GetBoolean(9),
                                    CuentaAhorroId = reader.GetInt32(10)
                                });
                            }
                            return View(beneficiarios);
                        }
                    }
                }
            }
            ViewBag.error = "Error: No hay ningun beneficiario";
            return View("Success");
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
        public IActionResult EditarBeneficiario(int id, string Nombre, int ParentescoId, DateTime FechaNacimiento,int DocId, string Doc,string Email,int PorcentajeBeneficio)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.EditarBeneficiario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ParentescoId", ParentescoId);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@DocId", DocId);
                    cmd.Parameters.AddWithValue("@Doc", Doc);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@PorcentajeBeneficio", PorcentajeBeneficio);
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int error = (int)returnParameter.Value;
                    switch (error)
                    {
                        case -100009:
                            ViewBag.error = "Error: Los porcentajes suman mas de 100";
                            break;
                        case -100010:
                            ViewBag.error = "Error: Los porcentajes suman menos de 100";
                            break;
                        default:
                            break;
                    }
                }
            }
            return View("Success");
        }
        public IActionResult Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.EliminarBeneficiario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id",id);
                    cmd.Parameters.AddWithValue("@FechaDesactivacion", DateTime.Today);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EliminarTelefono(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.EliminarTelefono", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarTelefono(int extension,int numero,int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.AgregarTelefono", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id",id);
                    cmd.Parameters.AddWithValue("@Numero", numero);
                    cmd.Parameters.AddWithValue("@Extension", extension);
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int error = (int)returnParameter.Value;
                    if(error == -100012)
                    {
                        ViewBag.error = "El telefono ya habia sido agregado";
                    }
                    else
                    {
                        ViewBag.error = "Telefono agregado con exito";
                    }
                }
            }
            //hasta aqui
            return View("Success");
        }

        public IActionResult ListarTelefonos(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarTelefonos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List < Telefono> Telefonos = new List<Telefono>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                Telefonos.Add(new Telefono
                                {
                                    Extension = reader.GetInt32(0),
                                    Numero = reader.GetInt32(1),
                                    ID = reader.GetInt32(2)
                                });
                            }
                            return View(Telefonos);
                        }
                    }
                }
            }
            ViewBag.error = "Error: El beneficiario no tiene ningun telefono";
            return View("Success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarBeneficiario(int PorcentajeBeneficio, int ParentescoId,string Nombre,DateTime FechaNacimiento,string Email,int DocId,string Doc,int Extension1, int Extension2, int Numero1, int Numero2)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.AgregarBeneficiario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@docId", DocId);
                    cmd.Parameters.AddWithValue("@doc", Doc);
                    cmd.Parameters.AddWithValue("@parentescoId", ParentescoId);
                    cmd.Parameters.AddWithValue("@porcentajeBeneficio", PorcentajeBeneficio);
                    cmd.Parameters.AddWithValue("@clienteId",HttpContext.Session.GetInt32("id"));
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int error = (int)returnParameter.Value;
                    switch (error)
                    {
                        case -100009:
                            ViewBag.error = "Error: Los porcentajes suman mas de 100";
                            break;
                        case -100010:
                            ViewBag.error = "Error: Los porcentajes suman menos de 100";
                            break;
                        case -100011:
                            ViewBag.error = "Error: El maximo de beneficiarios es de 3";
                            break;
                        default:
                            AgregarTelefono(Extension1,Numero1,error);
                            AgregarTelefono(Extension2, Numero2, error);
                            ViewBag.error = "Beneficiario agregado con exito";
                            break;
                    }
                }
            }
            //hasta aqui
            return View("Success");
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