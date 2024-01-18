using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarrolv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4160), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4197), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "UserName" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4215), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4214), "paperez_" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4055), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4057), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4059) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9684), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9683) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9696), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "UserName" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9710), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9709), "pperez_" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9567), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9569), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9570) });
        }
    }
}
