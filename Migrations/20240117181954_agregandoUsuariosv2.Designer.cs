﻿// <auto-generated />
using System;
using MiPrimeraAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MiPrimeraAPI.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240117181954_agregandoUsuariosv2")]
    partial class agregandoUsuariosv2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiPrimeraAPI.Models.NumberVilla", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDeActualización")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreación")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitacionesDisponibles")
                        .HasColumnType("int");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("NumeroVillas");
                });

            modelBuilder.Entity("MiPrimeraAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeActualización")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreación")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Pérez",
                            Contraseña = "123.@",
                            FechaDeActualización = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1490),
                            FechaDeCreación = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1489),
                            Gmail = "rperez@gmail.com",
                            Nombre = "Rodrigo",
                            Rol = "Administrador"
                        });
                });

            modelBuilder.Entity("MiPrimeraAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeActualización")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreación")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Ciudad = "Buenos Aires",
                            FechaDeActualización = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1346),
                            FechaDeCreación = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1331),
                            ImagenURL = "",
                            Nombre = "Edificio en la ciudad",
                            Pais = "Argentina"
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Ciudad = "Ibiza",
                            FechaDeActualización = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1348),
                            FechaDeCreación = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1347),
                            ImagenURL = "",
                            Nombre = "Casa en la playa",
                            Pais = "España"
                        },
                        new
                        {
                            Id = 3,
                            Amenidad = "",
                            Ciudad = "Mendoza",
                            FechaDeActualización = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1350),
                            FechaDeCreación = new DateTime(2024, 1, 17, 15, 19, 53, 728, DateTimeKind.Local).AddTicks(1349),
                            ImagenURL = "",
                            Nombre = "Cabaña en las montañas",
                            Pais = "Argentina"
                        });
                });

            modelBuilder.Entity("MiPrimeraAPI.Models.NumberVilla", b =>
                {
                    b.HasOne("MiPrimeraAPI.Models.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
