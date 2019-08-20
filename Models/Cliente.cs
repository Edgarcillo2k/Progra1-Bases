using System.ComponentModel.DataAnnotations;

namespace Progra1_bases.Models
{
    public class Cliente:Persona
    {
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }
        public CuentaAhorro CuentaAhorro { get; set; }
    }
}
