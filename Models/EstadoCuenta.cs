using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class EstadoCuenta
    {
        public int ID { get; set; }
        public int CuentaAhorroId { get; set; }
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha de finalizacion")]
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion { get; set; }
        [Display(Name = "Saldo inicial")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        [Display(Name = "Saldo final")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoFinal { get; set; }
        [Display(Name = "Retiros en cajero humano")]
        public int CantRetirosCajeroHumano { get; set; }
        [Display(Name = "Retiros en cajero automatico")]
        public int CantRetirosCajeroAutomatico { get; set; }
        [Display(Name = "Saldo minimo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoMinimo { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public virtual CuentaAhorro CuentaAhorro { get; set; }
    }
}
