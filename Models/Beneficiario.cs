using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<BeneficiarioPorCuenta> BeneficiarioPorCuenta { get; set; }
        public string NumCuenta { get; set; }
    }
}
