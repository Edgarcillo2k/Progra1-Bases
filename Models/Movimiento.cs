using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class Movimiento
    {
        public int ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public int EstadoCuentaId { get; set; }
        public int TipoMovimientoId { get; set; }
    }
}
