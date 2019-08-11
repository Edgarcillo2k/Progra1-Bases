using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progra1_Bases.Models
{
    public class CuentaAhorro
    {
        public int ID { get; set; }
        [Display(Name = "Monto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal monto { get; set; }
        [Display(Name = "Fecha de apertura")]
        [DataType(DataType.Date)]
        public DateTime? fechaApertura { get; set; }
        [Display(Name = "Moneda")]
        public int monedaId { get; set; }
        public int tipoCuentaId { get; set; }
    }
}
