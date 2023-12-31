using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class corrigiendoerrores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
