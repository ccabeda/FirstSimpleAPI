using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregandoUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeCreación = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeActualización = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "FechaDeActualización", "FechaDeCreación", "Nombre", "Rol" },
                values: new object[] { 1, "Pérez", "123.@", new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7228), new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7228), "Rodrigo", "Administrador" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7118), new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7120), new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7122), new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7121) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9216), new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9219), new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9220), new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9220) });
        }
    }
}
