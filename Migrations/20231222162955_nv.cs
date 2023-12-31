using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class nv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2726), new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2728), new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2727) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2729), new DateTime(2023, 12, 22, 13, 29, 55, 416, DateTimeKind.Local).AddTicks(2729) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5169), new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5171), new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaDeActualización", "FechaDeCreación" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5173), new DateTime(2023, 12, 22, 13, 26, 13, 655, DateTimeKind.Local).AddTicks(5172) });
        }
    }
}
