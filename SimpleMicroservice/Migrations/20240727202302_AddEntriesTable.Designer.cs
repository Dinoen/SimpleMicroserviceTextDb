﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SimpleMicroservice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240727202302_AddEntriesTable")]
    partial class AddEntriesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("SimpleMicroservice.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = "datablock1"
                        },
                        new
                        {
                            Id = 2,
                            Data = "datablock2"
                        },
                        new
                        {
                            Id = 3,
                            Data = "datablock3"
                        });
                });

            modelBuilder.Entity("SimpleMicroservice.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product1",
                            Price = 10.0m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Product2",
                            Price = 20.0m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Product3",
                            Price = 30.0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
