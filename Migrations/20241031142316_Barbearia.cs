using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class Barbearia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Agendamentos");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Agendamentos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Agendamentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Horario",
                table: "Agendamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
