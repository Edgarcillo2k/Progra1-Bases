using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progra1_Bases.Models;

namespace Progra1_bases.Models
{
    public class Progra1_basesContext : DbContext
    {
        public Progra1_basesContext (DbContextOptions<Progra1_basesContext> options)
            : base(options)
        {
        }

        public DbSet<Progra1_Bases.Models.Moneda> Moneda { get; set; }

        public DbSet<Progra1_Bases.Models.Cliente> Cliente { get; set; }

        public DbSet<Progra1_Bases.Models.Beneficiario> Beneficiario { get; set; }

        public DbSet<Progra1_Bases.Models.CuentaAhorro> CuentaAhorro { get; set; }

        public DbSet<Progra1_Bases.Models.CuentaObjetivo> CuentaObjetivo { get; set; }

        public DbSet<Progra1_Bases.Models.Doc> Doc { get; set; }

        public DbSet<Progra1_Bases.Models.EstadoCuenta> EstadoCuenta { get; set; }

        public DbSet<Progra1_Bases.Models.Movimiento> Movimiento { get; set; }

        public DbSet<Progra1_Bases.Models.Parentesco> Parentesco { get; set; }

        public DbSet<Progra1_Bases.Models.Persona> Persona { get; set; }

        public DbSet<Progra1_Bases.Models.PersonaPorTelefono> PersonaPorTelefono { get; set; }

        public DbSet<Progra1_Bases.Models.Telefono> Telefono { get; set; }

        public DbSet<Progra1_Bases.Models.TipoCuenta> TipoCuenta { get; set; }

        public DbSet<Progra1_Bases.Models.TipoMovimiento> TipoMovimiento { get; set; }
    }
}
