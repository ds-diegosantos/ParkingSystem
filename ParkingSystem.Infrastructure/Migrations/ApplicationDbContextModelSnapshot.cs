﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingSystem.Infrastructure.Context;

#nullable disable

namespace ParkingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParkingSystem.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("PriceTableId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PriceTableId")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ParkingSystem.Domain.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOccupied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("PriceTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("PayPerUse")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Subscription")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("PriceTables");
                });

            modelBuilder.Entity("ParkingSystem.Domain.Entities.Category", b =>
                {
                    b.HasOne("PriceTable", "PriceTable")
                        .WithOne("Category")
                        .HasForeignKey("ParkingSystem.Domain.Entities.Category", "PriceTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceTable");
                });

            modelBuilder.Entity("ParkingSystem.Domain.Entities.Spot", b =>
                {
                    b.HasOne("ParkingSystem.Domain.Entities.Category", "Category")
                        .WithMany("Spots")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ParkingSystem.Domain.Entities.Category", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("PriceTable", b =>
                {
                    b.Navigation("Category")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
