using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class TipoCuenta
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal saldoMinimo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal multaIncumplimientoSaldoMinimo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal montoMensualCargosServico { get; set; }
        public int maxRetirosCajeroHumano { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal multaRetiroCajeroHumanoExceso { get; set; }
        public int tasaInteres { get; set; }
        public List<CuentaAhorro> cuentas { get; set; }
    }
}
