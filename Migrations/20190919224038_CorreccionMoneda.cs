using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class CorreccionMoneda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaId",
                table: "CuentaAhorro");

            migrationBuilder.RenameColumn(
                name: "MonedaId",
                table: "CuentaAhorro",
                newName: "MonedaID");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaAhorro_MonedaId",
                table: "CuentaAhorro",
                newName: "IX_CuentaAhorro_MonedaID");

            migrationBuilder.AddColumn<int>(
                name: "MonedaId",
                table: "TipoCuenta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MonedaID",
                table: "CuentaAhorro",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaID",
                table: "CuentaAhorro",
                column: "MonedaID",
                principalTable: "Moneda",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaID",
                table: "CuentaAhorro");

            migrationBuilder.DropColumn(
                name: "MonedaId",
                table: "TipoCuenta");

            migrationBuilder.RenameColumn(
                name: "MonedaID",
                table: "CuentaAhorro",
                newName: "MonedaId");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaAhorro_MonedaID",
                table: "CuentaAhorro",
                newName: "IX_CuentaAhorro_MonedaId");

            migrationBuilder.AlterColumn<int>(
                name: "MonedaId",
                table: "CuentaAhorro",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaId",
                table: "CuentaAhorro",
                column: "MonedaId",
                principalTable: "Moneda",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
