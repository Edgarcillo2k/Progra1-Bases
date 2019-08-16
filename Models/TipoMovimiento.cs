using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class TipoMovimiento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Movimiento> Movimientos { get; set; }
    }
}
