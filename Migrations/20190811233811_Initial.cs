using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_Bases.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doc",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Simbolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parentesco",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentesco", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Extension = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    SaldoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MultaIncumplimientoSaldoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoMensualCargosServico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxRetirosCajeroHumano = table.Column<int>(nullable: false),
                    MultaRetiroCajeroHumanoExceso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaInteres = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CuentaObjetivo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    CuentaAhorroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaObjetivo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuentaAhorroId = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantRetirosCajeroHumano = table.Column<int>(nullable: false),
                    CantRetirosCajeroAutomatico = table.Column<int>(nullable: false),
                    SaldoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCuenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    EstadoCuentaId = table.Column<int>(nullable: false),
                    TipoMovimientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movimiento_EstadoCuenta_EstadoCuentaId",
                        column: x => x.EstadoCuentaId,
                        principalTable: "EstadoCuenta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_TipoMovimiento_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "TipoMovimiento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 40, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DocId = table.Column<int>(nullable: false),
                    Doc = table.Column<string>(maxLength: 20, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FechaDesactivacion = table.Column<DateTime>(nullable: true),
                    PorcentajeBeneficio = table.Column<int>(nullable: true),
                    ParentescoId = table.Column<int>(maxLength: 20, nullable: true),
                    Activo = table.Column<bool>(nullable: true),
                    CuentaAhorroId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persona_Parentesco_ParentescoId",
                        column: x => x.ParentescoId,
                        principalTable: "Parentesco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Doc_DocId",
                        column: x => x.DocId,
                        principalTable: "Doc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaAhorro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaApertura = table.Column<DateTime>(nullable: false),
                    MonedaId = table.Column<int>(nullable: false),
                    TipoCuentaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaAhorro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CuentaAhorro_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentaAhorro_Moneda_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Moneda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentaAhorro_TipoCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TipoCuenta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaPorTelefono",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonaId = table.Column<int>(nullable: false),
                    TelefonoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaPorTelefono", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonaPorTelefono_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaPorTelefono_Telefono_TelefonoID",
                        column: x => x.TelefonoID,
                        principalTable: "Telefono",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAhorro_ClienteId",
                table: "CuentaAhorro",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAhorro_MonedaId",
                table: "CuentaAhorro",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAhorro_TipoCuentaId",
                table: "CuentaAhorro",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo",
                column: "CuentaAhorroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_CuentaAhorroId",
                table: "EstadoCuenta",
                column: "CuentaAhorroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_EstadoCuentaId",
                table: "Movimiento",
                column: "EstadoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_TipoMovimientoId",
                table: "Movimiento",
                column: "TipoMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId",
                unique: true,
                filter: "[CuentaAhorroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ParentescoId",
                table: "Persona",
                column: "ParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DocId",
                table: "Persona",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTelefono_PersonaId",
                table: "PersonaPorTelefono",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTelefono_TelefonoID",
                table: "PersonaPorTelefono",
                column: "TelefonoID");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaObjetivo_CuentaAhorro_CuentaAhorroId",
                table: "CuentaObjetivo",
                column: "CuentaAhorroId",
                principalTable: "CuentaAhorro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_CuentaAhorro_CuentaAhorroId",
                table: "EstadoCuenta",
                column: "CuentaAhorroId",
                principalTable: "CuentaAhorro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_CuentaAhorro_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId",
                principalTable: "CuentaAhorro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAhorro_Persona_ClienteId",
                table: "CuentaAhorro");

            migrationBuilder.DropTable(
                name: "CuentaObjetivo");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "PersonaPorTelefono");

            migrationBuilder.DropTable(
                name: "EstadoCuenta");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "CuentaAhorro");

            migrationBuilder.DropTable(
                name: "Parentesco");

            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "TipoCuenta");
        }
    }
}
