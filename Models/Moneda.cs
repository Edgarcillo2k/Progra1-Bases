using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class Moneda
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Simbolo { get; set; }
        public List<CuentaAhorro> Cuentas { get; set; }
    }
}
