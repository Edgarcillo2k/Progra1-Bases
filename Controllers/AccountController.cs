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
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (HttpContext.Session.GetInt32("id") != null)
            {
                return View("Success");
            }
            return View();
        }

        public IActionResult AgregarBeneficiario()
        {
           
            ViewBag.documentos = ListarDocumentos();
            ViewBag.parentescos = ListarParentescos();
            
            return View();
        }

        public IActionResult AgregarCuentaObjetivo() {
            return View();
        }


        public IActionResult AgregarTelefono(int? id)
        {
            return View();
        }

        public IList<SelectListItem> ListarDocumentos()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarDocumentos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<SelectListItem> documentos = new List<SelectListItem>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                documentos.Add(new SelectListItem
                                {
                                    Value = Id.ToString(),
                                    Text = reader.GetString(1),
                                    
                                });
                            }
                            return documentos;
                        }
                    }
                }
            }
            ViewBag.error = "Error: No hay ningun Doc";
            return new List<SelectListItem>();
        }

        public IList<SelectListItem> ListarParentescos()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarParentesco", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<SelectListItem> parentescos = new List<SelectListItem>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                parentescos.Add(new SelectListItem
                                {
                                    
                                    Value = Id.ToString(),
                                    Text = reader.GetString(2),
                                });
                            }
                            return parentescos;
                        }
                    }
                }
            }
            ViewBag.error = "Error: No hay ningun Parentesco";
            return new List<SelectListItem>();
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
        public IActionResult ActualizarPorcentajes(int Id0,int Id1, int Id2,int Porcentaje0, int Porcentaje1 = -1, int Porcentaje2 = -1)
        {
            Porcentaje1 = Porcentaje1>0?Porcentaje1: 0;
            Porcentaje2 = Porcentaje2 > 0 ? Porcentaje2 : 0;
            if((Porcentaje0 + Porcentaje1 + Porcentaje2) == 100)
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("dbo.ActualizarPorcentajeBeneficio", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                        cmd.Parameters.AddWithValue("@IdBeneficiario1",Id0 );
                        cmd.Parameters.AddWithValue("@porcentajeBenef1",Porcentaje0 );
                        cmd.Parameters.AddWithValue("@IdBeneficiario2", Id1);
                        cmd.Parameters.AddWithValue("@porcentajeBenef2", Porcentaje1);
                        cmd.Parameters.AddWithValue("@IdBeneficiario3", Id2);
                        cmd.Parameters.AddWithValue("@porcentajeBenef3", Porcentaje2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        ViewBag.error = "Porcentajes actualizados con exito";
                    }
                }
            }
            else
            {
                ViewBag.error = "Los porcentajes de beneficio no suman 100";
            }
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


        public IActionResult ListarCuentasObjetivo()
        {
            
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarCuentasObjetivo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", HttpContext.Session.GetInt32("id"));
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<CuentaObjetivo> cuentasObjetivo = new List<CuentaObjetivo>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                cuentasObjetivo.Add(new CuentaObjetivo
                                {
                                    ID = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Descripcion = reader.GetString(2),
                                    FechaInicio = reader.GetDateTime(3),
                                    FechaFinalizacion = reader.GetDateTime(4),
                                    Monto = reader.GetDecimal(5),
                                    Saldo = reader.GetDecimal(6),
                                    NumCuenta = reader.GetString(7),
                                    CuentaAhorroId = reader.GetInt32(8)
                                }); 
                            }
                            return View(cuentasObjetivo);
                        }
                    }
                }
            }
            ViewBag.error = "Error: No hay ninguna cuenta objetivo registrada";
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
            ViewBag.documentos = ListarDocumentos();
            ViewBag.parentescos = ListarParentescos();
            return View(beneficiario);
        }
        public async Task<IActionResult> EditarCuentaObjetivo(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarBeneficiario(int id, string Nombre, int ParentescoId, DateTime FechaNacimiento,int DocId, string Doc,string Email)
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
                        case -100012:
                            ViewBag.error = "Error: El documento de identidad insertado ya esta en uso";
                            break;
                        default:
                            break;
                    }
                }
            }
            return View("Success");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCuentaObjetivo(int ID,string nombre, string descripcion, int monto)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.EditarCuentaObjetivo", con))
                {
                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", HttpContext.Session.GetInt32("id"));
                    cmd.Parameters.AddWithValue("@idCuentaObjetivo", ID);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            ViewBag.error = "Cuenta Objetivo: " + nombre + " Modificada";
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
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int error = (int)returnParameter.Value;
                    if (error == -100010)
                    {
                        ViewBag.error = "Los porcentajes de beneficio no suman 100";
                    }
                }
            }
            return View("Success");
        }
        public IActionResult DesactivarCuentaObjetivo(int nombre)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.DesactivarCuentaObjetivo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", HttpContext.Session.GetInt32("id"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            ViewBag.error = "Cuenta Objetivo Desactivada";
            return View("Success");
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

        public IActionResult ListarMovimientos(int id,string Filtro)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.ListarMovimientos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@substring", Filtro);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<Movimiento> Movimientos = new List<Movimiento>();
                            //si entra al if es porque encontro el dato buscado
                            while (reader.Read())
                            {
                                Movimientos.Add(new Movimiento
                                {
                                    TipoMovimiento = reader.GetString(0),
                                    Detalle = reader.GetString(1),
                                    Fecha = reader.GetDateTime(2),
                                    Monto = reader.GetDecimal(3)
                                });
                            }
                            return View(Movimientos);
                        }
                    }
                }
            }
            ViewBag.error = "No se encontro ningun movimiento";
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
                        case -100012:
                            ViewBag.error = "Error: El documento de identidad insertado ya esta en uso";
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarCuentaObjetivo(String nombre, String descripcion, int monto, DateTime fechaFinalizacion)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("dbo.AgregarCuentaObjetivo", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    //esto agrega los parametros, con @parametro especificas el nombre que tiene en el sp
                    cmd.Parameters.AddWithValue("@clienteId", HttpContext.Session.GetInt32("id"));
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@fechaFinalizacion", fechaFinalizacion);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //hasta aqui

            ViewBag.error = "Cuenta Objetivo Registrada";
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