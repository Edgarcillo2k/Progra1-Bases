using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_Bases.Models
{
    public class Beneficiario: Persona
    {
        [Display(Name = "Fecha de desactivacion")]
        [DataType(DataType.Date)]
        public DateTime FechaDesactivacion { get; set; }
        [Display(Name = "Porcentaje de beneficio")]
        public int PorcentajeBeneficio { get; set; }
        [Display(Name = "Parentesco")]
        [StringLength(20)]
        public int ParentescoId { get; set; }
        public bool Activo { get; set; }
        public int? CuentaAhorroId { get; set; }
    }
}
