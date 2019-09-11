using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Simbolo",
                table: "TipoCuenta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumCuenta",
                table: "Persona",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Parentesco",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detalle",
                table: "Parentesco",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intereses",
                table: "EstadoCuenta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NumCuenta",
                table: "EstadoCuenta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumCuenta",
                table: "CuentaObjetivo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Simbolo",
                table: "TipoCuenta");

            migrationBuilder.DropColumn(
                name: "NumCuenta",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "detalle",
                table: "Parentesco");

            migrationBuilder.DropColumn(
                name: "Intereses",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "NumCuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "NumCuenta",
                table: "CuentaObjetivo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Parentesco",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
