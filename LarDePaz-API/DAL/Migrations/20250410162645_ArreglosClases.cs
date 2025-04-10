using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LarDePaz_API.Migrations
{
    /// <inheritdoc />
    public partial class ArreglosClases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoTitularId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "SegundoTitularId",
                table: "Contrato");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TitularId",
                table: "Contrato",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Cliente_TitularId",
                table: "Contrato",
                column: "TitularId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Cliente_TitularId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_TitularId",
                table: "Contrato");

            migrationBuilder.AddColumn<int>(
                name: "CoTitularId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SegundoTitularId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
