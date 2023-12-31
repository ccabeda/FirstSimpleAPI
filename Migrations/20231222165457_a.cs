using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitacionesDisponibles",
                table: "NumeroVillas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(642), new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(645), new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(646), new DateTime(2023, 12, 22, 13, 54, 57, 558, DateTimeKind.Local).AddTicks(646) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HabitacionesDisponibles",
                table: "NumeroVillas");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9641), new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9632) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9644), new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9646), new DateTime(2023, 12, 22, 13, 47, 48, 240, DateTimeKind.Local).AddTicks(9645) });
        }
    }
}
