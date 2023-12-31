using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class numbertablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "NumeroVillas",
    columns: table => new
    {
        VillaNo = table.Column<int>(nullable: false),
        VillaId = table.Column<int>(nullable: false),
        // Otros campos de NumeroVillas
        FechaDeCreación = table.Column<DateTime>(nullable: false),
        FechaDeActualización = table.Column<DateTime>(nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_NumeroVillas", x => x.VillaNo);
        table.ForeignKey(
            name: "FK_NumeroVillas_villas_VillaId",
            column: x => x.VillaId,
            principalTable: "villas",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });
        }

        /// <inheritdoc />
       
    }
}
