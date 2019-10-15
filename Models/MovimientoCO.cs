using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class MovimientoCO
    {
        public int ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public int TipoMovimientoCOId { get; set; }
        public CuentaObjetivo CuentaObjetivo {get;set;}
        public virtual string TipoMovimiento { get; set; }
    }
}
