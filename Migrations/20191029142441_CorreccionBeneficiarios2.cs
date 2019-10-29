using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class CorreccionBeneficiarios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumCuenta",
                table: "BeneficiarioPorCuenta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentescoId",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumCuenta",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.DropColumn(
                name: "ParentescoId",
                table: "BeneficiarioPorCuenta");
        }
    }
}
