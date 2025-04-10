using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LarDePaz_API.Migrations
{
    /// <inheritdoc />
    public partial class InicioEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    NombreApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZonaDeCobro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratoCuotaHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImporteTotalPagado = table.Column<int>(type: "int", nullable: false),
                    ImporteTotalCuota = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    ImporteTotalPagado = table.Column<int>(type: "int", nullable: false),
                    ImporteTotalExpensa = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoExpensasHistorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manzana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumFilasMaximas = table.Column<int>(type: "int", nullable: false),
                    NumColumnasMaximas = table.Column<int>(type: "int", nullable: false),
                    PrecioExpesa = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manzana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoCuotaHistorialId = table.Column<int>(type: "int", nullable: false),
                    NumeroCuota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEmitida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importe = table.Column<int>(type: "int", nullable: false),
                    importePagado = table.Column<int>(type: "int", nullable: false),
                    ImporteInteres = table.Column<int>(type: "int", nullable: false),
                    ImporteTotal = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuota_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                        column: x => x.ContratoCuotaHistorialId,
                        principalTable: "ContratoCuotaHistorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobradorId = table.Column<int>(type: "int", nullable: false),
                    TitularId = table.Column<int>(type: "int", nullable: false),
                    CoTitularId = table.Column<int>(type: "int", nullable: false),
                    SegundoTitularId = table.Column<int>(type: "int", nullable: false),
                    ContratoCuotaHistorialId = table.Column<int>(type: "int", nullable: false),
                    ContratoExpensasHistorialId = table.Column<int>(type: "int", nullable: false),
                    NombreCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNICoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoCoTitular2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedSocialCoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNISegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoSegundoTitular2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedSocialSegundoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    CantidadCuotas = table.Column<int>(type: "int", nullable: false),
                    CuotasEmitidas = table.Column<int>(type: "int", nullable: false),
                    PagoAcumulado = table.Column<int>(type: "int", nullable: false),
                    CantidadParcelas = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Cobrador_CobradorId",
                        column: x => x.CobradorId,
                        principalTable: "Cobrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_ContratoCuotaHistorial_ContratoCuotaHistorialId",
                        column: x => x.ContratoCuotaHistorialId,
                        principalTable: "ContratoCuotaHistorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                        column: x => x.ContratoExpensasHistorialId,
                        principalTable: "ContratoExpensasHistorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expensa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoExpensasHistorialId = table.Column<int>(type: "int", nullable: false),
                    NumPeriodo = table.Column<int>(type: "int", nullable: false),
                    YearPeriodo = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<int>(type: "int", nullable: false),
                    ImportePagado = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expensa_ContratoExpensasHistorial_ContratoExpensasHistorialId",
                        column: x => x.ContratoExpensasHistorialId,
                        principalTable: "ContratoExpensasHistorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManzanaId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NombreDescriptivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioCompra = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zona_Manzana_ManzanaId",
                        column: x => x.ManzanaId,
                        principalTable: "Manzana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Columna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parcela_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelaContratoHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelaId = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelaContratoHistorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelaContratoHistorial_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelaContratoHistorial_Parcela_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CobradorId",
                table: "Contrato",
                column: "CobradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ContratoCuotaHistorialId",
                table: "Contrato",
                column: "ContratoCuotaHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ContratoExpensasHistorialId",
                table: "Contrato",
                column: "ContratoExpensasHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_ContratoCuotaHistorialId",
                table: "Cuota",
                column: "ContratoCuotaHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensa_ContratoExpensasHistorialId",
                table: "Expensa",
                column: "ContratoExpensasHistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_ContratoId",
                table: "Parcela",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_ZonaId",
                table: "Parcela",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelaContratoHistorial_ContratoId",
                table: "ParcelaContratoHistorial",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelaContratoHistorial_ParcelaId",
                table: "ParcelaContratoHistorial",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Zona_ManzanaId",
                table: "Zona",
                column: "ManzanaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "Expensa");

            migrationBuilder.DropTable(
                name: "ParcelaContratoHistorial");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Cobrador");

            migrationBuilder.DropTable(
                name: "ContratoCuotaHistorial");

            migrationBuilder.DropTable(
                name: "ContratoExpensasHistorial");

            migrationBuilder.DropTable(
                name: "Manzana");
        }
    }
}
