using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class TipoCuenta
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoMinimo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MultaIncumplimientoSaldoMinimo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoMensualCargosServico { get; set; }
        public int MaxRetirosCajeroHumano { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MultaRetiroCajeroHumanoExceso { get; set; }
        public int TasaInteres { get; set; }
        public List<CuentaAhorro> Cuentas { get; set; }
    }
}
