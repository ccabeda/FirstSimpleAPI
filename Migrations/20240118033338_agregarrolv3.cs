using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarrolv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4564), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4576), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4590) });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "FechaDeActualización", "FechaDeCreación", "Gmail", "Nombre", "RolId", "UserName" },
                values: new object[] { 10, "Pérez", "123.@", new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4604), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4604), "rperez@gmail.com", "Lautaro", 1, "pperez_" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4449), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4451), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4453), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4452) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10);

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
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4215), new DateTime(2024, 1, 18, 0, 31, 58, 696, DateTimeKind.Local).AddTicks(4214) });

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
    }
}
