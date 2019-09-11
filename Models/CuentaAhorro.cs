using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progra1_bases.Models
{
    public class CuentaAhorro
    {
        public int ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        [Display(Name = "Fecha de apertura")]
        [DataType(DataType.Date)]
        public DateTime FechaApertura { get; set; }
        [Display(Name = "Moneda")]
        public int MonedaId { get; set; }
        [Display(Name = "Tipo de cuenta")]
        public int TipoCuentaId { get; set; }
        public List<EstadoCuenta> EstadoCuenta { get; set; }
        public List<Beneficiario> Beneficiario { get; set; }
        public CuentaObjetivo CuentaObjetivo { get; set; }
        public int ClienteId { get; set; }
        public string NumCuenta { get; set; }
    }
}
