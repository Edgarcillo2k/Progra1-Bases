using System.Collections.Generic;

namespace Progra1_Bases.Models
{
    public class Parentesco
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public List<Beneficiario> beneficiarios { get; set; }
    }
}
