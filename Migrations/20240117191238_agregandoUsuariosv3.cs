using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregandoUsuariosv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "UserName" },
                values: new object[] { new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1901), new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1900), "pperez_" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1749), new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1751), new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1751) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1753), new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1753) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1490), new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1489) });

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
    }
}
