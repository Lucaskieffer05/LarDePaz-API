﻿// <auto-generated />
using System;
using LarDePaz_API.DAL.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LarDePaz_API.Migrations
{
    [DbContext(typeof(APIContext))]
    partial class APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LarDePaz_API.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Cobrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZonaDeCobro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cobrador");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadCuotas")
                        .HasColumnType("int");

                    b.Property<int>("CobradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNICoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNISegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DireccionCoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailCoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaContrato")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GenerarExpensas")
                        .HasColumnType("bit");

                    b.Property<string>("LocalidadCoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalidadPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalidadSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugarPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinciaCoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinciaPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinciaSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedSocialCoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedSocialSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCoTitular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCoTitular2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoSegundoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoSegundoTitular2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TitularId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CobradorId");

                    b.HasIndex("TitularId");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContratoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmitida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Importe")
                        .HasColumnType("int");

                    b.Property<int>("ImporteInteres")
                        .HasColumnType("int");

                    b.Property<int>("ImportePagado")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCuota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Expensa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContratoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("Importe")
                        .HasColumnType("int");

                    b.Property<int>("ImportePagado")
                        .HasColumnType("int");

                    b.Property<int>("NumPeriodo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("YearPeriodo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Expensa");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Manzana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumColumnasMaximas")
                        .HasColumnType("int");

                    b.Property<int>("NumFilasMaximas")
                        .HasColumnType("int");

                    b.Property<int>("PrecioExpesa")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Manzana");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Columna")
                        .HasColumnType("int");

                    b.Property<int?>("ContratoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fila")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.HasIndex("ZonaId");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("LarDePaz_API.Models.ParcelaContratoHistorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContratoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParcelaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.HasIndex("ParcelaId");

                    b.ToTable("ParcelaContratoHistorial");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LarDePaz_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManzanaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreDescriptivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PrecioCompra")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManzanaId");

                    b.ToTable("Zona");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Contrato", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Cobrador", "Cobrador")
                        .WithMany()
                        .HasForeignKey("CobradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LarDePaz_API.Models.Cliente", "Titular")
                        .WithMany("Contratos")
                        .HasForeignKey("TitularId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobrador");

                    b.Navigation("Titular");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Cuota", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Contrato", "Contrato")
                        .WithMany("Cuotas")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Expensa", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Contrato", "Contrato")
                        .WithMany("Expensas")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Parcela", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Contrato", null)
                        .WithMany("Parcelas")
                        .HasForeignKey("ContratoId");

                    b.HasOne("LarDePaz_API.Models.Zona", "Zona")
                        .WithMany("Parcelas")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("LarDePaz_API.Models.ParcelaContratoHistorial", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Contrato", "Contrato")
                        .WithMany()
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LarDePaz_API.Models.Parcela", "Parcela")
                        .WithMany("ContratosHistorial")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");

                    b.Navigation("Parcela");
                });

            modelBuilder.Entity("LarDePaz_API.Models.User", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Zona", b =>
                {
                    b.HasOne("LarDePaz_API.Models.Manzana", "Manzana")
                        .WithMany("Zonas")
                        .HasForeignKey("ManzanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manzana");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Cliente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Contrato", b =>
                {
                    b.Navigation("Cuotas");

                    b.Navigation("Expensas");

                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Manzana", b =>
                {
                    b.Navigation("Zonas");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Parcela", b =>
                {
                    b.Navigation("ContratosHistorial");
                });

            modelBuilder.Entity("LarDePaz_API.Models.Zona", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
