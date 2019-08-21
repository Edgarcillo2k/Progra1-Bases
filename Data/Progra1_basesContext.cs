using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Progra1_bases.Models
{
    public class Progra1_basesContext : DbContext
    {
        public Progra1_basesContext (DbContextOptions<Progra1_basesContext> options)
            : base(options)
        {
        }

        public DbSet<Progra1_bases.Models.Moneda> Moneda { get; set; }

        public DbSet<Progra1_bases.Models.Cliente> Cliente { get; set; }

        public DbSet<Progra1_bases.Models.Beneficiario> Beneficiario { get; set; }

        public DbSet<Progra1_bases.Models.CuentaAhorro> CuentaAhorro { get; set; }

        public DbSet<Progra1_bases.Models.CuentaObjetivo> CuentaObjetivo { get; set; }

        public DbSet<Progra1_bases.Models.Doc> Doc { get; set; }

        public DbSet<Progra1_bases.Models.EstadoCuenta> EstadoCuenta { get; set; }

        public DbSet<Progra1_bases.Models.Movimiento> Movimiento { get; set; }

        public DbSet<Progra1_bases.Models.Parentesco> Parentesco { get; set; }

        public DbSet<Progra1_bases.Models.Persona> Persona { get; set; }

        public DbSet<Progra1_bases.Models.PersonaPorTelefono> PersonaPorTelefono { get; set; }

        public DbSet<Progra1_bases.Models.Telefono> Telefono { get; set; }

        public DbSet<Progra1_bases.Models.TipoCuenta> TipoCuenta { get; set; }

        public DbSet<Progra1_bases.Models.TipoMovimiento> TipoMovimiento { get; set; }
    }
}
