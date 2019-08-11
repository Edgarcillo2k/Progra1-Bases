﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Progra1_Bases.Models;

namespace Progra1_Bases.Migrations
{
    [DbContext(typeof(Progra1_BasesContext))]
    partial class Progra1_BasesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Progra1_Bases.Models.CuentaAhorro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("FechaApertura");

                    b.Property<int>("MonedaId");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoCuentaId");

                    b.HasKey("ID");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("MonedaId");

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("CuentaAhorro");
                });

            modelBuilder.Entity("Progra1_Bases.Models.CuentaObjetivo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuentaAhorroId");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CuentaAhorroId")
                        .IsUnique();

                    b.ToTable("CuentaObjetivo");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Doc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("Doc");
                });

            modelBuilder.Entity("Progra1_Bases.Models.EstadoCuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantRetirosCajeroAutomatico");

                    b.Property<int>("CantRetirosCajeroHumano");

                    b.Property<int>("CuentaAhorroId");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<decimal>("SaldoFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoMinimo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CuentaAhorroId")
                        .IsUnique();

                    b.ToTable("EstadoCuenta");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Moneda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("Simbolo");

                    b.HasKey("ID");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Movimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalle");

                    b.Property<int>("EstadoCuentaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoMovimientoId");

                    b.HasKey("ID");

                    b.HasIndex("EstadoCuentaId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Parentesco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("Parentesco");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Doc")
                        .HasMaxLength(20);

                    b.Property<int>("DocId");

                    b.Property<string>("Email");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.HasIndex("DocId");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Progra1_Bases.Models.PersonaPorTelefono", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonaId");

                    b.Property<int?>("TelefonoID");

                    b.HasKey("ID");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.HasIndex("TelefonoID");

                    b.ToTable("PersonaPorTelefono");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Telefono", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Extension");

                    b.Property<int>("Numero");

                    b.HasKey("ID");

                    b.ToTable("Telefono");
                });

            modelBuilder.Entity("Progra1_Bases.Models.TipoCuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxRetirosCajeroHumano");

                    b.Property<decimal>("MontoMensualCargosServico")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MultaIncumplimientoSaldoMinimo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MultaRetiroCajeroHumanoExceso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("SaldoMinimo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TasaInteres");

                    b.HasKey("ID");

                    b.ToTable("TipoCuenta");
                });

            modelBuilder.Entity("Progra1_Bases.Models.TipoMovimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("TipoMovimiento");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Beneficiario", b =>
                {
                    b.HasBaseType("Progra1_Bases.Models.Persona");

                    b.Property<bool>("Activo");

                    b.Property<int>("CuentaAhorroId");

                    b.Property<DateTime>("FechaDesactivacion");

                    b.Property<int>("ParentescoId")
                        .HasMaxLength(20);

                    b.Property<int>("PorcentajeBeneficio");

                    b.HasIndex("CuentaAhorroId")
                        .IsUnique()
                        .HasFilter("[CuentaAhorroId] IS NOT NULL");

                    b.HasIndex("ParentescoId");

                    b.HasDiscriminator().HasValue("Beneficiario");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Cliente", b =>
                {
                    b.HasBaseType("Progra1_Bases.Models.Persona");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Progra1_Bases.Models.CuentaAhorro", b =>
                {
                    b.HasOne("Progra1_Bases.Models.Cliente")
                        .WithOne("CuentaAhorro")
                        .HasForeignKey("Progra1_Bases.Models.CuentaAhorro", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_Bases.Models.Moneda")
                        .WithMany("Cuentas")
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_Bases.Models.TipoCuenta")
                        .WithMany("Cuentas")
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_Bases.Models.CuentaObjetivo", b =>
                {
                    b.HasOne("Progra1_Bases.Models.CuentaAhorro")
                        .WithOne("CuentaObjetivo")
                        .HasForeignKey("Progra1_Bases.Models.CuentaObjetivo", "CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_Bases.Models.EstadoCuenta", b =>
                {
                    b.HasOne("Progra1_Bases.Models.CuentaAhorro")
                        .WithOne("EstadoCuenta")
                        .HasForeignKey("Progra1_Bases.Models.EstadoCuenta", "CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_Bases.Models.Movimiento", b =>
                {
                    b.HasOne("Progra1_Bases.Models.EstadoCuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("EstadoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_Bases.Models.TipoMovimiento")
                        .WithMany("Movimientos")
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_Bases.Models.Persona", b =>
                {
                    b.HasOne("Progra1_Bases.Models.Doc")
                        .WithMany("Personas")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_Bases.Models.PersonaPorTelefono", b =>
                {
                    b.HasOne("Progra1_Bases.Models.Persona")
                        .WithOne("PersonaPorTelefono")
                        .HasForeignKey("Progra1_Bases.Models.PersonaPorTelefono", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_Bases.Models.Telefono", "Telefono")
                        .WithMany("PersonasPorTelefono")
                        .HasForeignKey("TelefonoID");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Beneficiario", b =>
                {
                    b.HasOne("Progra1_Bases.Models.CuentaAhorro")
                        .WithOne("Beneficiario")
                        .HasForeignKey("Progra1_Bases.Models.Beneficiario", "CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_Bases.Models.Parentesco")
                        .WithMany("Beneficiarios")
                        .HasForeignKey("ParentescoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
