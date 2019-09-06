using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class PersonaPorTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonaPorTelefono_PersonaId",
                table: "PersonaPorTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTelefono_PersonaId",
                table: "PersonaPorTelefono",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonaPorTelefono_PersonaId",
                table: "PersonaPorTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTelefono_PersonaId",
                table: "PersonaPorTelefono",
                column: "PersonaId",
                unique: true);
        }
    }
}
