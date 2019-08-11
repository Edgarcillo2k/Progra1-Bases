using System.ComponentModel.DataAnnotations;

namespace Progra1_Bases.Models
{
    public class Cliente:Persona
    {
        [Display(Name = "Clave")]
        public string password { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string username { get; set; }
    }
}
