﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaPackageSystem.Infrastructure.Repository;

#nullable disable

namespace SantaPackageSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240208181011_addNullableTypes")]
    partial class addNullableTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("SantaPackageSystem.Models.Elf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnLeave")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnParentalLeave")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Elves");
                });

            modelBuilder.Entity("SantaPackageSystem.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssignedElfId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssignedElfId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("SantaPackageSystem.Models.Package", b =>
                {
                    b.HasOne("SantaPackageSystem.Models.Elf", "AssignedElf")
                        .WithMany()
                        .HasForeignKey("AssignedElfId");

                    b.Navigation("AssignedElf");
                });
#pragma warning restore 612, 618
        }
    }
}
