using System.Collections.Generic;

namespace Progra1_bases.Models
{
    public class Parentesco
    {
        public int ID { get; set; }
        public char Nombre { get; set; }
        public string detalle { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }
    }
}
