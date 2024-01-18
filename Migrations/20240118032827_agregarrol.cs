using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarrol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeCreación = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeActualización = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "FechaDeActualización", "FechaDeCreación", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9684), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9683), "Administrador" },
                    { 2, new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9696), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9695), "Usuario" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "RolId" },
                values: new object[] { new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9710), new DateTime(2024, 1, 18, 0, 28, 26, 707, DateTimeKind.Local).AddTicks(9709), 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación", "Rol" },
                values: new object[] { new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1901), new DateTime(2024, 1, 17, 16, 12, 38, 264, DateTimeKind.Local).AddTicks(1900), "Administrador" });

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
    }
}
