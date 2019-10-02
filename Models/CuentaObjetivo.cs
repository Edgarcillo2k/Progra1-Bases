using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progra1_bases.Models
{
    public class CuentaObjetivo
    {
        public int ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        public string Nombre { get; set; }
        public int CuentaAhorroId { get; set; }
        public string NumCuenta { get; set; }
        public string Descripcion { get; set; }
        public int Desactivada { get; set; }
    }
}
