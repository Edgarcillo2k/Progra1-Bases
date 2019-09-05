using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class PersonaPorTelefono
    {
        public int ID { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }
        public int TelefonoId { get; set; }
        public virtual Telefono Telefono{get;set;}
    }
}
