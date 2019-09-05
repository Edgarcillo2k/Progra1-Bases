using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Telefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaPorTelefono_Telefono_TelefonoID",
                table: "PersonaPorTelefono");

            migrationBuilder.RenameColumn(
                name: "TelefonoID",
                table: "PersonaPorTelefono",
                newName: "TelefonoId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaPorTelefono_TelefonoID",
                table: "PersonaPorTelefono",
                newName: "IX_PersonaPorTelefono_TelefonoId");

            migrationBuilder.AlterColumn<int>(
                name: "TelefonoId",
                table: "PersonaPorTelefono",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Persona",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persona",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Doc",
                table: "Persona",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaPorTelefono_Telefono_TelefonoId",
                table: "PersonaPorTelefono",
                column: "TelefonoId",
                principalTable: "Telefono",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaPorTelefono_Telefono_TelefonoId",
                table: "PersonaPorTelefono");

            migrationBuilder.RenameColumn(
                name: "TelefonoId",
                table: "PersonaPorTelefono",
                newName: "TelefonoID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaPorTelefono_TelefonoId",
                table: "PersonaPorTelefono",
                newName: "IX_PersonaPorTelefono_TelefonoID");

            migrationBuilder.AlterColumn<int>(
                name: "TelefonoID",
                table: "PersonaPorTelefono",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Persona",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persona",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Doc",
                table: "Persona",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaPorTelefono_Telefono_TelefonoID",
                table: "PersonaPorTelefono",
                column: "TelefonoID",
                principalTable: "Telefono",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
