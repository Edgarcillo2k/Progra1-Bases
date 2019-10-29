using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class CorreccionPorcentaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_TipoEvento_TipoEventoID",
                table: "Evento");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEventoID",
                table: "Evento",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeBeneficio",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_TipoEvento_TipoEventoID",
                table: "Evento",
                column: "TipoEventoID",
                principalTable: "TipoEvento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_TipoEvento_TipoEventoID",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "PorcentajeBeneficio",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEventoID",
                table: "Evento",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_TipoEvento_TipoEventoID",
                table: "Evento",
                column: "TipoEventoID",
                principalTable: "TipoEvento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
