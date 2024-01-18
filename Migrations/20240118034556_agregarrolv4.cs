using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarrolv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(646), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(658), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(657) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "FechaDeActualización", "FechaDeCreación", "Nombre" },
                values: new object[] { 3, new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(668), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(667), "SuperAdmin" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(682), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(681) });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "FechaDeActualización", "FechaDeCreación", "Gmail", "Nombre", "RolId", "UserName" },
                values: new object[] { 11, "Messi", "123.@", new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(695), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(694), "leo@gmail.com", "Leonel", 2, "jorgemessi" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(516), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(519), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(518) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(521), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(521) });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "FechaDeActualización", "FechaDeCreación", "Gmail", "Nombre", "RolId", "UserName" },
                values: new object[] { 12, "Peña", "123.@", new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(707), new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(706), "doblep@gmail.com", "Pedro", 3, "doblep" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

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
                keyValue: 10,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4604), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4604) });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "FechaDeActualización", "FechaDeCreación", "Gmail", "Nombre", "RolId", "UserName" },
                values: new object[] { 1, "Pérez", "123.@", new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 1, 18, 0, 33, 37, 960, DateTimeKind.Local).AddTicks(4590), "rperez@gmail.com", "Rodrigo", 1, "paperez_" });

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
    }
}
