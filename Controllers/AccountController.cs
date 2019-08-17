using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Progra1_bases.Models;

namespace Progra1_bases.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly Progra1_basesContext _context;

        public AccountController(Progra1_basesContext context)
        {
            _context = context;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //if (_context.Cliente.Any(e => e.Username == username) && _context.Cliente.Any(e => e.Password == password)) esto es mas rapido
            //pero no se como hacer que revise en el mismo elemento si la contrasenia coincide
            var clientes = from c in _context.Cliente
                         select c;

            if (!String.IsNullOrEmpty(username))
            {
                clientes = clientes.Where(s => s.Username.Equals(username) && s.Password.Equals(password));
                if (clientes.Count() > 0)
                {
                    HttpContext.Session.SetString("username", username);
                    return View("Success");
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}