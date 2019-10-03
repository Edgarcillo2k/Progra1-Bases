using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_CuentaAhorro_CuentaAhorroId",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo");

            migrationBuilder.DropColumn(
                name: "CuentaAhorroId",
                table: "Persona");

            migrationBuilder.AddColumn<int>(
                name: "Desactivada",
                table: "CuentaObjetivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "CuentaObjetivo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BeneficiarioPorCuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeneficiarioId = table.Column<int>(nullable: false),
                    CuentaAhorroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiarioPorCuenta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BeneficiarioPorCuenta_Persona_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiarioPorCuenta_CuentaAhorro_CuentaAhorroId",
                        column: x => x.CuentaAhorroId,
                        principalTable: "CuentaAhorro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo",
                column: "CuentaAhorroId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarioPorCuenta_BeneficiarioId",
                table: "BeneficiarioPorCuenta",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarioPorCuenta_CuentaAhorroId",
                table: "BeneficiarioPorCuenta",
                column: "CuentaAhorroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiarioPorCuenta");

            migrationBuilder.DropIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo");

            migrationBuilder.DropColumn(
                name: "Desactivada",
                table: "CuentaObjetivo");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "CuentaObjetivo");

            migrationBuilder.AddColumn<int>(
                name: "CuentaAhorroId",
                table: "Persona",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaObjetivo_CuentaAhorroId",
                table: "CuentaObjetivo",
                column: "CuentaAhorroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_CuentaAhorro_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId",
                principalTable: "CuentaAhorro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
