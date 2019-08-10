using System.Collections.Generic;

namespace Progra1_Bases.Models
{
    public class Doc
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public List<Persona> personas { get; set; }
    }
}
