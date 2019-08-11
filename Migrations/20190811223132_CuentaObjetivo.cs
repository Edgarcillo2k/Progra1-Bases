using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_Bases.Migrations
{
    public partial class CuentaObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CuentaAhorro",
                nullable: false,
                defaultValue: 0);

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
                    table.ForeignKey(
                        name: "FK_CuentaObjetivo_CuentaAhorro_CuentaAhorroId",
                        column: x => x.CuentaAhorroId,
                        principalTable: "CuentaAhorro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAhorro_ClienteId",
                table: "CuentaAhorro",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo",
                column: "CuentaAhorroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAhorro_Persona_ClienteId",
                table: "CuentaAhorro",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAhorro_Persona_ClienteId",
                table: "CuentaAhorro");

            migrationBuilder.DropTable(
                name: "CuentaObjetivo");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAhorro_ClienteId",
                table: "CuentaAhorro");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CuentaAhorro");
        }
    }
}
