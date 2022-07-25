﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse_MS.Data;

namespace Warehouse_MS.Migrations
{
    [DbContext(typeof(WarehouseDBContext))]
    [Migration("20220725004334_role")]
    partial class role
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "admin",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "supervisor",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "supervisor",
                            NormalizedName = "SUPERVISOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Warehouse_MS.Auth.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarcodeNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SizeInUnit")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("StorageTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("StorageId");

                    b.HasIndex("StorageTypeId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product1",
                            ProductTypeId = 1,
                            SizeInUnit = 5,
                            StorageId = 1,
                            StorageTypeId = 1,
                            Weight = 100.0
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product2",
                            ProductTypeId = 4,
                            SizeInUnit = 3,
                            StorageId = 1,
                            StorageTypeId = 1,
                            Weight = 200.0
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product3",
                            ProductTypeId = 1,
                            SizeInUnit = 5,
                            StorageId = 1,
                            StorageTypeId = 1,
                            Weight = 150.0
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product4",
                            ProductTypeId = 2,
                            SizeInUnit = 1,
                            StorageId = 2,
                            StorageTypeId = 2,
                            Weight = 104.0
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product5",
                            ProductTypeId = 1,
                            SizeInUnit = 10,
                            StorageId = 2,
                            StorageTypeId = 2,
                            Weight = 430.0
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2018, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product6",
                            ProductTypeId = 3,
                            SizeInUnit = 2,
                            StorageId = 3,
                            StorageTypeId = 3,
                            Weight = 110.0
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2010, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " ....",
                            ExpiredDate = new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Product7",
                            ProductTypeId = 4,
                            SizeInUnit = 15,
                            StorageId = 5,
                            StorageTypeId = 4,
                            Weight = 300.0
                        });
                });

            modelBuilder.Entity("Warehouse_MS.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "....",
                            Name = "food"
                        },
                        new
                        {
                            Id = 2,
                            Description = "....",
                            Name = "metals"
                        },
                        new
                        {
                            Id = 3,
                            Description = "....",
                            Name = "Cleaning materials"
                        },
                        new
                        {
                            Id = 4,
                            Description = "....",
                            Name = "raw material"
                        });
                });

            modelBuilder.Entity("Warehouse_MS.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationInWarehouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeInUnit")
                        .HasColumnType("int");

                    b.Property<int>("StorageTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StorageTypeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Storage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " ....",
                            LocationInWarehouse = "floor 1 west",
                            Name = "Storage1",
                            SizeInUnit = 15,
                            StorageTypeId = 1,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = " ....",
                            LocationInWarehouse = "floor 2 east",
                            Name = "Storage2",
                            SizeInUnit = 30,
                            StorageTypeId = 2,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = " ....",
                            LocationInWarehouse = "floor 1 behind the fridge ",
                            Name = "Storage3",
                            SizeInUnit = 55,
                            StorageTypeId = 3,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = " ....",
                            LocationInWarehouse = "floor 1 production section",
                            Name = "Storage4",
                            SizeInUnit = 25,
                            StorageTypeId = 3,
                            WarehouseId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = " ....",
                            LocationInWarehouse = "floor 2 between section a and section t",
                            Name = "Storage5",
                            SizeInUnit = 25,
                            StorageTypeId = 4,
                            WarehouseId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = " ....",
                            LocationInWarehouse = "floor 1 south",
                            Name = "Storage6",
                            SizeInUnit = 50,
                            StorageTypeId = 3,
                            WarehouseId = 3
                        },
                        new
                        {
                            Id = 7,
                            Description = " ....",
                            LocationInWarehouse = "floor 1 west",
                            Name = "Storage7",
                            SizeInUnit = 50,
                            StorageTypeId = 2,
                            WarehouseId = 4
                        });
                });

            modelBuilder.Entity("Warehouse_MS.Models.StorageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StorageType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "....",
                            Name = "low temperature"
                        },
                        new
                        {
                            Id = 2,
                            Description = "....",
                            Name = "on shelves"
                        },
                        new
                        {
                            Id = 3,
                            Description = "....",
                            Name = "on the floor"
                        },
                        new
                        {
                            Id = 4,
                            Description = "....",
                            Name = "recycle area"
                        });
                });

            modelBuilder.Entity("Warehouse_MS.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OldLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("newLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Warehouse_MS.Models.UserWarehouse", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "WarehouseId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("UserWarehouse");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeInUnit")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " ....",
                            Location = "Amman",
                            Name = "Warehouse1",
                            SizeInUnit = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = " ....",
                            Location = "aqaba",
                            Name = "Warehouse2",
                            SizeInUnit = 50
                        },
                        new
                        {
                            Id = 3,
                            Description = " ....",
                            Location = "Irbid",
                            Name = "Warehouse3",
                            SizeInUnit = 150
                        },
                        new
                        {
                            Id = 4,
                            Description = " ....",
                            Location = "zarqa",
                            Name = "Warehouse4",
                            SizeInUnit = 200
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse_MS.Models.Product", b =>
                {
                    b.HasOne("Warehouse_MS.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Models.Storage", "Storage")
                        .WithMany("Products")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Models.StorageType", "StorageType")
                        .WithMany("Products")
                        .HasForeignKey("StorageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Storage");

                    b.Navigation("StorageType");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Storage", b =>
                {
                    b.HasOne("Warehouse_MS.Models.StorageType", "StorageType")
                        .WithMany("Storages")
                        .HasForeignKey("StorageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Models.Warehouse", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StorageType");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Transaction", b =>
                {
                    b.HasOne("Warehouse_MS.Models.Product", "Product")
                        .WithMany("Transaction")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Warehouse_MS.Models.UserWarehouse", b =>
                {
                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_MS.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Warehouse", b =>
                {
                    b.HasOne("Warehouse_MS.Auth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Warehouses")
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Warehouse_MS.Auth.Models.ApplicationUser", b =>
                {
                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Product", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Warehouse_MS.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Storage", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Warehouse_MS.Models.StorageType", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("Warehouse_MS.Models.Warehouse", b =>
                {
                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
