using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class TipoMovimientoCO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Movimiento> MovimientosCO { get; set; }
    }
}
