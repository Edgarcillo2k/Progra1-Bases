using System;
using System.ComponentModel.DataAnnotations;

namespace Progra1_Bases.Models
{
    public class Persona
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }
        public string email { get; set; }
        //public string docId { get; set; }
    }
}
