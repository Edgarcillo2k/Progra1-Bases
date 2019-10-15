﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Progra1_bases.Models;

namespace Progra1_bases.Migrations
{
    [DbContext(typeof(Progra1_basesContext))]
    [Migration("20191015140653_MovimientosCO")]
    partial class MovimientosCO
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Progra1_bases.Models.BeneficiarioPorCuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("BeneficiarioId");

                    b.Property<int?>("CuentaAhorroId");

                    b.Property<DateTime>("FechaDesactivacion");

                    b.HasKey("ID");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("CuentaAhorroId");

                    b.ToTable("BeneficiarioPorCuenta");
                });

            modelBuilder.Entity("Progra1_bases.Models.CuentaAhorro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("FechaApertura");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumCuenta");

                    b.Property<int>("TipoCuentaId");

                    b.HasKey("ID");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("CuentaAhorro");
                });

            modelBuilder.Entity("Progra1_bases.Models.CuentaObjetivo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuentaAhorroId");

                    b.Property<int>("Desactivada");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre");

                    b.Property<string>("NumCuenta");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CuentaAhorroId");

                    b.ToTable("CuentaObjetivo");
                });

            modelBuilder.Entity("Progra1_bases.Models.Doc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("Doc");
                });

            modelBuilder.Entity("Progra1_bases.Models.EstadoCuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantRetirosCajeroAutomatico");

                    b.Property<int>("CantRetirosCajeroHumano");

                    b.Property<int>("CuentaAhorroId");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<int>("Intereses");

                    b.Property<string>("NumCuenta");

                    b.Property<decimal>("SaldoFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoMinimo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CuentaAhorroId");

                    b.ToTable("EstadoCuenta");
                });

            modelBuilder.Entity("Progra1_bases.Models.Moneda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("Simbolo");

                    b.HasKey("ID");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("Progra1_bases.Models.Movimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalle");

                    b.Property<int>("EstadoCuentaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoMovimiento");

                    b.Property<int>("TipoMovimientoId");

                    b.HasKey("ID");

                    b.HasIndex("EstadoCuentaId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("Progra1_bases.Models.MovimientoCO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CuentaObjetivoID");

                    b.Property<string>("Detalle");

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoMovimientoCOId");

                    b.HasKey("ID");

                    b.HasIndex("CuentaObjetivoID");

                    b.ToTable("MovimientoCO");
                });

            modelBuilder.Entity("Progra1_bases.Models.Parentesco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("detalle");

                    b.HasKey("ID");

                    b.ToTable("Parentesco");
                });

            modelBuilder.Entity("Progra1_bases.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Doc")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("DocId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.HasIndex("DocId");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Progra1_bases.Models.PersonaPorTelefono", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonaId");

                    b.Property<int>("TelefonoId");

                    b.HasKey("ID");

                    b.HasIndex("PersonaId");

                    b.HasIndex("TelefonoId");

                    b.ToTable("PersonaPorTelefono");
                });

            modelBuilder.Entity("Progra1_bases.Models.Telefono", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Extension");

                    b.Property<int>("Numero");

                    b.HasKey("ID");

                    b.ToTable("Telefono");
                });

            modelBuilder.Entity("Progra1_bases.Models.TipoCuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxRetirosCajeroHumano");

                    b.Property<int>("MonedaId");

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

                    b.HasIndex("MonedaId");

                    b.ToTable("TipoCuenta");
                });

            modelBuilder.Entity("Progra1_bases.Models.TipoMovimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("TipoMovimiento");
                });

            modelBuilder.Entity("Progra1_bases.Models.Beneficiario", b =>
                {
                    b.HasBaseType("Progra1_bases.Models.Persona");

                    b.Property<string>("NumCuenta");

                    b.Property<int>("ParentescoId");

                    b.Property<int>("PorcentajeBeneficio");

                    b.HasIndex("ParentescoId");

                    b.HasDiscriminator().HasValue("Beneficiario");
                });

            modelBuilder.Entity("Progra1_bases.Models.Cliente", b =>
                {
                    b.HasBaseType("Progra1_bases.Models.Persona");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Progra1_bases.Models.BeneficiarioPorCuenta", b =>
                {
                    b.HasOne("Progra1_bases.Models.Beneficiario", "Beneficiario")
                        .WithMany("BeneficiarioPorCuenta")
                        .HasForeignKey("BeneficiarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_bases.Models.CuentaAhorro", "CuentaAhorro")
                        .WithMany("BeneficiarioPorCuenta")
                        .HasForeignKey("CuentaAhorroId");
                });

            modelBuilder.Entity("Progra1_bases.Models.CuentaAhorro", b =>
                {
                    b.HasOne("Progra1_bases.Models.Cliente")
                        .WithOne("CuentaAhorro")
                        .HasForeignKey("Progra1_bases.Models.CuentaAhorro", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_bases.Models.TipoCuenta")
                        .WithMany("Cuentas")
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.CuentaObjetivo", b =>
                {
                    b.HasOne("Progra1_bases.Models.CuentaAhorro")
                        .WithMany("CuentaObjetivo")
                        .HasForeignKey("CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.EstadoCuenta", b =>
                {
                    b.HasOne("Progra1_bases.Models.CuentaAhorro", "CuentaAhorro")
                        .WithMany("EstadoCuenta")
                        .HasForeignKey("CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.Movimiento", b =>
                {
                    b.HasOne("Progra1_bases.Models.EstadoCuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("EstadoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_bases.Models.TipoMovimiento")
                        .WithMany("Movimientos")
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.MovimientoCO", b =>
                {
                    b.HasOne("Progra1_bases.Models.CuentaObjetivo")
                        .WithMany("MovimientosCO")
                        .HasForeignKey("CuentaObjetivoID");
                });

            modelBuilder.Entity("Progra1_bases.Models.Persona", b =>
                {
                    b.HasOne("Progra1_bases.Models.Doc")
                        .WithMany("Personas")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.PersonaPorTelefono", b =>
                {
                    b.HasOne("Progra1_bases.Models.Persona", "Persona")
                        .WithMany("PersonaPorTelefono")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Progra1_bases.Models.Telefono", "Telefono")
                        .WithMany("PersonasPorTelefono")
                        .HasForeignKey("TelefonoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.TipoCuenta", b =>
                {
                    b.HasOne("Progra1_bases.Models.Moneda")
                        .WithMany("TipoCuentas")
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Progra1_bases.Models.Beneficiario", b =>
                {
                    b.HasOne("Progra1_bases.Models.Parentesco")
                        .WithMany("Beneficiarios")
                        .HasForeignKey("ParentescoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
