using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_Bases.Models
{
    public class PersonaPorTelefono
    {
        public int ID { get; set; }
        public int PersonaId { get; set; }
        public Telefono Telefono { get; set; }
    }
}
