using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class Telefono
    {
        public int ID { get; set; }
        public List<PersonaPorTelefono> PersonasPorTelefono { get; set; }
        public int Extension { get; set; }
        public int Numero { get; set; }
    }
}
