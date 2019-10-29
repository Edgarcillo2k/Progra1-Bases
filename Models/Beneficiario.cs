using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progra1_bases.Models
{
    public class Beneficiario: Persona
    {
        [Required]
        [Display(Name = "Parentesco")]
        public virtual int ParentescoId { get; set; }
        public virtual string NumCuenta { get; set; }
        [Display(Name = "Porcentaje de beneficio")]
        public virtual int PorcentajeBeneficio { get; set; }
        public List<BeneficiarioPorCuenta> BeneficiarioPorCuenta { get; set; }
    }
}
