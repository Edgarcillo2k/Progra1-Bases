using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Progra1_Bases.Models;

namespace Progra1_bases.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source =LAPTOP-DQQUAKNL; database=WPF; integrated security = SSPI;";
        }
        public ActionResult Verify(Cliente cliente)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select"
            return View();
        }
    }
}