using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Prueba2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoCOID",
                table: "Movimiento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientoCO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientoCO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PersonaId = table.Column<int>(nullable: false),
                    XMLAntes = table.Column<string>(nullable: true),
                    XMLDespues = table.Column<string>(nullable: true),
                    TipoEventoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evento_TipoEvento_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "TipoEvento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_TipoMovimientoCOID",
                table: "Movimiento",
                column: "TipoMovimientoCOID");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoEventoID",
                table: "Evento",
                column: "TipoEventoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimiento_TipoMovimientoCO_TipoMovimientoCOID",
                table: "Movimiento",
                column: "TipoMovimientoCOID",
                principalTable: "TipoMovimientoCO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimiento_TipoMovimientoCO_TipoMovimientoCOID",
                table: "Movimiento");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "TipoMovimientoCO");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropIndex(
                name: "IX_Movimiento_TipoMovimientoCOID",
                table: "Movimiento");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoCOID",
                table: "Movimiento");
        }
    }
}
