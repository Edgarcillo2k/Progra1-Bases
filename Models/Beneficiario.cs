using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_Bases.Models
{
    public class Beneficiario: Persona
    {
        [Display(Name = "Fecha de desactivacion")]
        [DataType(DataType.Date)]
        public DateTime? fechaDesactivacion { get; set; }
        [Display(Name = "Porcentaje de beneficio")]
        public int porcentajeBeneficio { get; set; }
        [Display(Name = "Parentesco")]
        public int parentescoId { get; set; }
        [Display(Name = "Activo")]
        public bool activo { get; set; }
    }
}
