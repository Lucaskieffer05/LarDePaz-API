using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LarDePaz_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionesClienteYZona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZonaId",
                table: "Cobrador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZonaId",
                table: "Cobrador",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
