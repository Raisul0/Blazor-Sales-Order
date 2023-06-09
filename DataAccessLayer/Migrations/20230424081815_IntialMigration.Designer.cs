﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20230424081815_IntialMigration")]
    partial class IntialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Entities.Locations.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            StateName = "NY"
                        },
                        new
                        {
                            StateId = 2,
                            StateName = "CA"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("StateId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderName = "New York Building 1",
                            StateId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            OrderName = "California Hotel AJK",
                            StateId = 2
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderWindow", b =>
                {
                    b.Property<int>("OrderWindowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderWindowId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("WindowId")
                        .HasColumnType("int");

                    b.Property<int>("WindowQuantity")
                        .HasColumnType("int");

                    b.HasKey("OrderWindowId");

                    b.HasIndex("OrderId");

                    b.HasIndex("WindowId");

                    b.ToTable("OrderWindows");

                    b.HasData(
                        new
                        {
                            OrderWindowId = 1,
                            OrderId = 1,
                            WindowId = 1,
                            WindowQuantity = 4
                        },
                        new
                        {
                            OrderWindowId = 2,
                            OrderId = 1,
                            WindowId = 2,
                            WindowQuantity = 2
                        },
                        new
                        {
                            OrderWindowId = 3,
                            OrderId = 2,
                            WindowId = 3,
                            WindowQuantity = 3
                        },
                        new
                        {
                            OrderWindowId = 4,
                            OrderId = 2,
                            WindowId = 4,
                            WindowQuantity = 10
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElementId"));

                    b.Property<int>("ElementTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("ElementId");

                    b.HasIndex("ElementTypeId");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            ElementId = 1,
                            ElementTypeId = 1,
                            Height = 1850,
                            Width = 1200
                        },
                        new
                        {
                            ElementId = 2,
                            ElementTypeId = 2,
                            Height = 1850,
                            Width = 800
                        },
                        new
                        {
                            ElementId = 3,
                            ElementTypeId = 2,
                            Height = 1850,
                            Width = 700
                        },
                        new
                        {
                            ElementId = 4,
                            ElementTypeId = 2,
                            Height = 2000,
                            Width = 1500
                        },
                        new
                        {
                            ElementId = 5,
                            ElementTypeId = 1,
                            Height = 2200,
                            Width = 1400
                        },
                        new
                        {
                            ElementId = 6,
                            ElementTypeId = 2,
                            Height = 2200,
                            Width = 600
                        },
                        new
                        {
                            ElementId = 7,
                            ElementTypeId = 2,
                            Height = 2000,
                            Width = 1500
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.ElementType", b =>
                {
                    b.Property<int>("ElementTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElementTypeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ElementTypeId");

                    b.ToTable("ElementTypes");

                    b.HasData(
                        new
                        {
                            ElementTypeId = 1,
                            Description = "Door type Elements",
                            ElementTypeName = "Doors"
                        },
                        new
                        {
                            ElementTypeId = 2,
                            Description = "Window type Elements",
                            ElementTypeName = "Windows"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.Window", b =>
                {
                    b.Property<int>("WindowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WindowId"));

                    b.Property<string>("WindowName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WindowId");

                    b.ToTable("Windows");

                    b.HasData(
                        new
                        {
                            WindowId = 1,
                            WindowName = "A51"
                        },
                        new
                        {
                            WindowId = 2,
                            WindowName = "C Zone 5"
                        },
                        new
                        {
                            WindowId = 3,
                            WindowName = "GLB"
                        },
                        new
                        {
                            WindowId = 4,
                            WindowName = "OHF"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.WindowElement", b =>
                {
                    b.Property<int>("WindowElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WindowElementId"));

                    b.Property<int>("ElementId")
                        .HasColumnType("int");

                    b.Property<int>("WindowId")
                        .HasColumnType("int");

                    b.HasKey("WindowElementId");

                    b.HasIndex("ElementId");

                    b.HasIndex("WindowId");

                    b.ToTable("WindowElements");

                    b.HasData(
                        new
                        {
                            WindowElementId = 1,
                            ElementId = 1,
                            WindowId = 1
                        },
                        new
                        {
                            WindowElementId = 2,
                            ElementId = 2,
                            WindowId = 1
                        },
                        new
                        {
                            WindowElementId = 3,
                            ElementId = 3,
                            WindowId = 1
                        },
                        new
                        {
                            WindowElementId = 4,
                            ElementId = 4,
                            WindowId = 2
                        },
                        new
                        {
                            WindowElementId = 5,
                            ElementId = 5,
                            WindowId = 3
                        },
                        new
                        {
                            WindowElementId = 6,
                            ElementId = 6,
                            WindowId = 3
                        },
                        new
                        {
                            WindowElementId = 7,
                            ElementId = 7,
                            WindowId = 4
                        },
                        new
                        {
                            WindowElementId = 8,
                            ElementId = 7,
                            WindowId = 4
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.Order", b =>
                {
                    b.HasOne("DomainLayer.Entities.Locations.State", "State")
                        .WithMany("Orders")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderWindow", b =>
                {
                    b.HasOne("DomainLayer.Entities.Orders.Order", "Order")
                        .WithMany("OrderWindows")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Entities.Products.Window", "Window")
                        .WithMany("OrderWindows")
                        .HasForeignKey("WindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Window");
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.Element", b =>
                {
                    b.HasOne("DomainLayer.Entities.Products.ElementType", "ElementType")
                        .WithMany("Elements")
                        .HasForeignKey("ElementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElementType");
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.WindowElement", b =>
                {
                    b.HasOne("DomainLayer.Entities.Products.Element", "Element")
                        .WithMany("WindowElements")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Entities.Products.Window", "Window")
                        .WithMany("WindowElements")
                        .HasForeignKey("WindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("Window");
                });

            modelBuilder.Entity("DomainLayer.Entities.Locations.State", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.Order", b =>
                {
                    b.Navigation("OrderWindows");
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.Element", b =>
                {
                    b.Navigation("WindowElements");
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.ElementType", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("DomainLayer.Entities.Products.Window", b =>
                {
                    b.Navigation("OrderWindows");

                    b.Navigation("WindowElements");
                });
#pragma warning restore 612, 618
        }
    }
}
