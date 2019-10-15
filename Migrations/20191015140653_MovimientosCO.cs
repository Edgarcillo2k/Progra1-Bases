using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class MovimientosCO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaDesactivacion",
                table: "Persona");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDesactivacion",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MovimientoCO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    TipoMovimientoCOId = table.Column<int>(nullable: false),
                    CuentaObjetivoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovimientoCO_CuentaObjetivo_CuentaObjetivoID",
                        column: x => x.CuentaObjetivoID,
                        principalTable: "CuentaObjetivo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCO_CuentaObjetivoID",
                table: "MovimientoCO",
                column: "CuentaObjetivoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientoCO");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.DropColumn(
                name: "FechaDesactivacion",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDesactivacion",
                table: "Persona",
                nullable: true);
        }
    }
}
