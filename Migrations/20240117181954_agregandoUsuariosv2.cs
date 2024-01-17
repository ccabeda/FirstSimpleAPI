using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregandoUsuariosv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "Gmail" },
                values: new object[] { new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1490), new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1489), "rperez@gmail.com" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1346), new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1348), new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1349) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7228), new DateTime(2024, 1, 17, 11, 29, 41, 274, DateTimeKind.Local).AddTicks(7228) });

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
    }
}
