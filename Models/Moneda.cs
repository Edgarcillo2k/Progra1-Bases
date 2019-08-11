using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class Moneda
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string simbolo { get; set; }
        public List<CuentaAhorro> cuentas { get; set; }
    }
}
