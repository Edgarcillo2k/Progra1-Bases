using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_bases.Models
{
    public class Beneficiario: Persona
    {
        [Required]
        [Display(Name = "Fecha de desactivacion")]
        [DataType(DataType.Date)]
        public DateTime FechaDesactivacion { get; set; }
        [Required]
        [Display(Name = "Porcentaje de beneficio")]
        public int PorcentajeBeneficio { get; set; }
        [Required]
        [Display(Name = "Parentesco")]
        public int ParentescoId { get; set; }
        public bool Activo { get; set; }
        public int? CuentaAhorroId { get; set; }
        public virtual CuentaAhorro CuentaAhorro { get; set; }
    }
}
