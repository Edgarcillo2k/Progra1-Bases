using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Progra1_bases.Models;

namespace Progra1_bases.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source =LAPTOP-DQQUAKNL; database=Progra1_basesContext-cc2a59df-30b1-41c9-975d-b217d4396835; integrated security = SSPI;";
        }
        public ActionResult Verify(Cliente cliente)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='"+ cliente.Username+"' and passwprd='"+cliente.Password;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
        }
    }
}