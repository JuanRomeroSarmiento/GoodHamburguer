﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationWriteDbContext))]
    partial class ApplicationWriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Domain.Menus.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"),
                            Name = "FastFood"
                        });
                });

            modelBuilder.Entity("Domain.Menus.MenuCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"),
                            MenuId = new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"),
                            Name = "Sandwich"
                        },
                        new
                        {
                            Id = new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"),
                            MenuId = new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"),
                            Name = "Extras"
                        });
                });

            modelBuilder.Entity("Domain.Menus.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MenuCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6cf893b-4af8-422c-ab76-1b02b43df73a"),
                            MenuCategoryId = new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"),
                            Name = "X Burger",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = new Guid("76240b4e-cebe-41b9-bb48-87227de07207"),
                            MenuCategoryId = new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"),
                            Name = "X Egg",
                            Price = 4.50m
                        },
                        new
                        {
                            Id = new Guid("f41adb1c-7ef9-467a-9ed5-2f855a63b412"),
                            MenuCategoryId = new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"),
                            Name = "X Bacon",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = new Guid("89e255d5-5184-49cf-b254-86968537d9d4"),
                            MenuCategoryId = new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"),
                            Name = "Fries",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("e6c48b6a-f10f-4b20-beac-1067763e2a22"),
                            MenuCategoryId = new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"),
                            Name = "Soft drink",
                            Price = 2.50m
                        });
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GrossPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("NetPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Orders.OrderMenuItem", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OrderMenuItems");
                });

            modelBuilder.Entity("Domain.Menus.MenuCategory", b =>
                {
                    b.HasOne("Domain.Menus.Menu", "Menu")
                        .WithMany("Categories")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Domain.Menus.MenuItem", b =>
                {
                    b.HasOne("Domain.Menus.MenuCategory", "Category")
                        .WithMany("Items")
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Orders.OrderMenuItem", b =>
                {
                    b.HasOne("Domain.Menus.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Orders.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Menus.Menu", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Domain.Menus.MenuCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Menus.MenuItem", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderMenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
