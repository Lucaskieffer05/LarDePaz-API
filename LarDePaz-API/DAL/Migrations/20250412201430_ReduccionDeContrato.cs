using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LarDePaz_API.Migrations
{
    /// <inheritdoc />
    public partial class ReduccionDeContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuota_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                table: "Cuota");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensa_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                table: "Expensa");

            migrationBuilder.DropTable(
                name: "ContratoCuotaHistorial");

            migrationBuilder.DropTable(
                name: "ContratoExpensasHistorial");

            migrationBuilder.DropIndex(
                name: "IX_Cuota_ContratoCuotaHistorialId",
                table: "Cuota");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_ContratoCuotaHistorialId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_ContratoExpensasHistorialId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ContratoCuotaHistorialId",
                table: "Cuota");

            migrationBuilder.DropColumn(
                name: "CantidadParcelas",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ContratoCuotaHistorialId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ContratoExpensasHistorialId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "CuotasEmitidas",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "PagoAcumulado",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "ContratoExpensasHistorialId",
                table: "Expensa",
                newName: "ContratoId");

            migrationBuilder.RenameIndex(
                name: "IX_Expensa_ContratoExpensasHistorialId",
                table: "Expensa",
                newName: "IX_Expensa_ContratoId");

            migrationBuilder.RenameColumn(
                name: "importePagado",
                table: "Cuota",
                newName: "ImportePagado");

            migrationBuilder.RenameColumn(
                name: "ImporteTotal",
                table: "Cuota",
                newName: "ContratoId");

            migrationBuilder.AddColumn<bool>(
                name: "GenerarExpensas",
                table: "Contrato",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_ContratoId",
                table: "Cuota",
                column: "ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuota_Contrato_ContratoId",
                table: "Cuota",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expensa_Contrato_ContratoId",
                table: "Expensa",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuota_Contrato_ContratoId",
                table: "Cuota");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensa_Contrato_ContratoId",
                table: "Expensa");

            migrationBuilder.DropIndex(
                name: "IX_Cuota_ContratoId",
                table: "Cuota");

            migrationBuilder.DropColumn(
                name: "GenerarExpensas",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "ContratoId",
                table: "Expensa",
                newName: "ContratoExpensasHistorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Expensa_ContratoId",
                table: "Expensa",
                newName: "IX_Expensa_ContratoExpensasHistorialId");

            migrationBuilder.RenameColumn(
                name: "ImportePagado",
                table: "Cuota",
                newName: "importePagado");

            migrationBuilder.RenameColumn(
                name: "ContratoId",
                table: "Cuota",
                newName: "ImporteTotal");

            migrationBuilder.AddColumn<int>(
                name: "ContratoCuotaHistorialId",
                table: "Cuota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadParcelas",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContratoCuotaHistorialId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContratoExpensasHistorialId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuotasEmitidas",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagoAcumulado",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Saldo",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContratoCuotaHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImporteTotalCuota = table.Column<int>(type: "int", nullable: false),
                    ImporteTotalPagado = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoCuotaHistorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratoExpensasHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImporteTotalExpensa = table.Column<int>(type: "int", nullable: false),
                    ImporteTotalPagado = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoExpensasHistorial", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_ContratoCuotaHistorialId",
                table: "Cuota",
                column: "ContratoCuotaHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ContratoCuotaHistorialId",
                table: "Contrato",
                column: "ContratoCuotaHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ContratoExpensasHistorialId",
                table: "Contrato",
                column: "ContratoExpensasHistorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                table: "Contrato",
                column: "ContratoCuotaHistorialId",
                principalTable: "ContratoCuotaHistorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                table: "Contrato",
                column: "ContratoExpensasHistorialId",
                principalTable: "ContratoExpensasHistorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuota_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                table: "Cuota",
                column: "ContratoCuotaHistorialId",
                principalTable: "ContratoCuotaHistorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expensa_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                table: "Expensa",
                column: "ContratoExpensasHistorialId",
                principalTable: "ContratoExpensasHistorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
