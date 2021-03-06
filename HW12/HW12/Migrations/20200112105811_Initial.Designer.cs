﻿// <auto-generated />
using System;
using HW12.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HW12.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20200112105811_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HW12.Models.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasPaid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("903275db-7a98-438f-80fc-648dbb6f0527"),
                            HasPaid = false
                        });
                });

            modelBuilder.Entity("HW12.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b3c14f9-1e2d-4f8a-a05a-9ef6d2cb0bc9"),
                            Cost = 250,
                            Name = "Pepsi"
                        },
                        new
                        {
                            Id = new Guid("eabac71d-a6ac-4b04-a7b8-f0094eb1d0f4"),
                            Cost = 150,
                            Name = "Cola"
                        },
                        new
                        {
                            Id = new Guid("64dbe577-5f83-4133-9e7e-3b815f4b5db8"),
                            Cost = 200,
                            Name = "Snickers"
                        });
                });

            modelBuilder.Entity("HW12.Models.Product", b =>
                {
                    b.HasOne("HW12.Models.Basket", "Basket")
                        .WithMany("Products")
                        .HasForeignKey("BasketId");
                });
#pragma warning restore 612, 618
        }
    }
}
