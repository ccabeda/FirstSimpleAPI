using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarLaTablaDeVillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenidad", "Ciudad", "FechaDeActualización", "FechaDeCareación", "ImagenURL", "Nombre", "Pais" },
                values: new object[,]
                {
                    { 1, "", "Buenos Aires", new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(365), new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(356), "", "Edificio en la ciudad", "Argentina" },
                    { 2, "", "Ibiza", new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(367), new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(367), "", "Casa en la playa", "España" },
                    { 3, "", "Mendoza", new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(370), new DateTime(2023, 12, 17, 11, 52, 54, 771, DateTimeKind.Local).AddTicks(369), "", "Cabaña en las montañas", "Argentina" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
