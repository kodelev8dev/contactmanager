﻿// <auto-generated />
using System;
using ContactManager.Service.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManager.Service.Migrations
{
    [DbContext(typeof(ContactManagerContext))]
    [Migration("20240618090103_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactManager.Service.Model.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Created = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(3990),
                            Email = "iUqFP@example.com",
                            IsDeleted = false,
                            LastUpdated = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020),
                            Name = "John Doe",
                            Notes = "Test contact",
                            Phone = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Oak St",
                            Created = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020),
                            Email = "b2yJn@example.com",
                            IsDeleted = false,
                            LastUpdated = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020),
                            Name = "Jane Doe",
                            Notes = "Test contact",
                            Phone = "0987654321"
                        },
                        new
                        {
                            Id = 3,
                            Address = "123 Main St",
                            Created = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030),
                            Email = "iUqFP@example.com",
                            IsDeleted = false,
                            LastUpdated = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030),
                            Name = "John Smith",
                            Notes = "Test contact",
                            Phone = "1234567890"
                        },
                        new
                        {
                            Id = 4,
                            Address = "456 Oak St",
                            Created = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030),
                            Email = "b2yJn@example.com",
                            IsDeleted = true,
                            LastUpdated = new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030),
                            Name = "Jane Smith",
                            Notes = "Test contact",
                            Phone = "0987654321"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
