using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class BeneficiarioPorCuenta
    {
        public int ID { get; set; }
        public int BeneficiarioId { get; set; }
        public virtual Beneficiario Beneficiario { get; set; }
        public int? CuentaAhorroId { get; set; }
        public virtual CuentaAhorro CuentaAhorro { get; set; }
        [Display(Name = "Fecha de desactivacion")]
        [DataType(DataType.Date)]
        public DateTime? FechaDesactivacion { get; set; }
        public bool Activo { get; set; }
    }
}
