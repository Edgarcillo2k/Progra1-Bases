using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace Progra1_bases.Models
{
    public class Evento
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string XMLAntes { get; set; }
        public string XMLDespues { get; set; }
        public int TipoEventoID { get; set; }
    }
}
