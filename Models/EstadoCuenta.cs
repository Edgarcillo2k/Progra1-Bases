using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class EstadoCuenta
    {
        public int ID { get; set; }
        public int CuentaAhorroId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoFinal { get; set; }
        public int CantRetirosCajeroHumano { get; set; }
        public int CantRetirosCajeroAutomatico { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoMinimo { get; set; }
        public List<Movimiento> Movimientos { get; set; }
    }
}
