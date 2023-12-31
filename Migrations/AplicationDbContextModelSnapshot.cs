﻿// <auto-generated />
using System;
using MiPrimeraAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


#nullable disable

namespace MiPrimeraAPI.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
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
                            FechaDeActualización = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9216),
                            FechaDeCreación = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9205),
                            ImagenURL = "",
                            Nombre = "Edificio en la ciudad",
                            Pais = "Argentina"
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Ciudad = "Ibiza",
                            FechaDeActualización = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9219),
                            FechaDeCreación = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9218),
                            ImagenURL = "",
                            Nombre = "Casa en la playa",
                            Pais = "España"
                        },
                        new
                        {
                            Id = 3,
                            Amenidad = "",
                            Ciudad = "Mendoza",
                            FechaDeActualización = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9220),
                            FechaDeCreación = new DateTime(2023, 12, 22, 13, 58, 7, 746, DateTimeKind.Local).AddTicks(9220),
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
