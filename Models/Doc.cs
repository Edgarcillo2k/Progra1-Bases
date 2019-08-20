using System.Collections.Generic;

namespace Progra1_bases.Models
{
    public class Doc
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Persona> Personas { get; set; }
    }
}
