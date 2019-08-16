using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_bases.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [StringLength(40)]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        [Display(Name = "Tipo de documento de identidad")]
        public int DocId { get; set; }
        [Display(Name = "Documento de identidad")]
        [StringLength(20)]
        public string Doc { get; set; }
        public PersonaPorTelefono PersonaPorTelefono { get; set; }
    }
}
