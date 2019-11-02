using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class TipoEvento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Evento> Eventos { get; set; }
        public int TipoDeEvento { get; set; }
    }
}
