using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_Bases.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Tipo de documento de identidad")]
        public int docId { get; set; }
        [Display(Name = "Documento de identidad")]
        public int doc { get; set; }
    }
}
