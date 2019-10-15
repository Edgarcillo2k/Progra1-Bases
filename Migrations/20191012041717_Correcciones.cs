using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Correcciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaDesactivacion",
                table: "Persona");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDesactivacion",
                table: "BeneficiarioPorCuenta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.DropColumn(
                name: "FechaDesactivacion",
                table: "BeneficiarioPorCuenta");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDesactivacion",
                table: "Persona",
                nullable: true);
        }
    }
}
