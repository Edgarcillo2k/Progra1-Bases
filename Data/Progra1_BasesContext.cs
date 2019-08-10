using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Progra1_Bases.Models
{
    public class Progra1_BasesContext : DbContext
    {
        public Progra1_BasesContext (DbContextOptions<Progra1_BasesContext> options)
            : base(options)
        {
        }

        public DbSet<Progra1_Bases.Models.Persona> Persona { get; set; }
    }
}
