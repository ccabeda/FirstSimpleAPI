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
    [Migration("20240118034556_agregarrolv4")]
    partial class agregarrolv4
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

            modelBuilder.Entity("MiPrimeraAPI.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaDeActualización")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreación")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(646),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(645),
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(658),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(657),
                            Nombre = "Usuario"
                        },
                        new
                        {
                            Id = 3,
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(668),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(667),
                            Nombre = "SuperAdmin"
                        });
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

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Apellido = "Pérez",
                            Contraseña = "123.@",
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(682),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(681),
                            Gmail = "rperez@gmail.com",
                            Nombre = "Lautaro",
                            RolId = 1,
                            UserName = "pperez_"
                        },
                        new
                        {
                            Id = 11,
                            Apellido = "Messi",
                            Contraseña = "123.@",
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(695),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(694),
                            Gmail = "leo@gmail.com",
                            Nombre = "Leonel",
                            RolId = 2,
                            UserName = "jorgemessi"
                        },
                        new
                        {
                            Id = 12,
                            Apellido = "Peña",
                            Contraseña = "123.@",
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(707),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(706),
                            Gmail = "doblep@gmail.com",
                            Nombre = "Pedro",
                            RolId = 3,
                            UserName = "doblep"
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
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(516),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(506),
                            ImagenURL = "",
                            Nombre = "Edificio en la ciudad",
                            Pais = "Argentina"
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Ciudad = "Ibiza",
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(519),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(518),
                            ImagenURL = "",
                            Nombre = "Casa en la playa",
                            Pais = "España"
                        },
                        new
                        {
                            Id = 3,
                            Amenidad = "",
                            Ciudad = "Mendoza",
                            FechaDeActualización = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(521),
                            FechaDeCreación = new DateTime(2024, 1, 18, 0, 45, 56, 347, DateTimeKind.Local).AddTicks(521),
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

            modelBuilder.Entity("MiPrimeraAPI.Models.Usuario", b =>
                {
                    b.HasOne("MiPrimeraAPI.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}