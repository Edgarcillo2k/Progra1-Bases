using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class TipoCuentasCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaID",
                table: "CuentaAhorro");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAhorro_MonedaID",
                table: "CuentaAhorro");

            migrationBuilder.DropColumn(
                name: "MonedaID",
                table: "CuentaAhorro");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCuenta_MonedaId",
                table: "TipoCuenta",
                column: "MonedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCuenta_Moneda_MonedaId",
                table: "TipoCuenta",
                column: "MonedaId",
                principalTable: "Moneda",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoCuenta_Moneda_MonedaId",
                table: "TipoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_TipoCuenta_MonedaId",
                table: "TipoCuenta");

            migrationBuilder.AddColumn<int>(
                name: "MonedaID",
                table: "CuentaAhorro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAhorro_MonedaID",
                table: "CuentaAhorro",
                column: "MonedaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAhorro_Moneda_MonedaID",
                table: "CuentaAhorro",
                column: "MonedaID",
                principalTable: "Moneda",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
