using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Progra1_bases.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Tipo de documento de identidad")]
        public int DocId { get; set; }
        [Required]
        [Display(Name = "Documento de identidad")]
        [StringLength(20)]
        public string Doc { get; set; }
        public List<PersonaPorTelefono> PersonaPorTelefono { get; set; }
    }
}
