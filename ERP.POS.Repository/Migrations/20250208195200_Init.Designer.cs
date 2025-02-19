﻿// <auto-generated />
using System;
using ERP.POS.Repository.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.POS.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250208195200_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("ERP.POS.Domain.Entities.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CurrencyValue")
                        .HasColumnType("REAL");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxRatio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.BillItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BillId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TaxRatio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("MaterialId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("DiscRatio")
                        .HasColumnType("REAL");

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MaximumSales")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.CustomerBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerBranches");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("REAL");

                    b.Property<decimal>("Tax")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Bill", b =>
                {
                    b.HasOne("ERP.POS.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ERP.POS.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ERP.POS.Domain.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ERP.POS.Domain.Entities.OwnedEntities.Discount", "Discount", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Ratio")
                                .HasColumnType("REAL")
                                .HasColumnName("DiscountRatio");

                            b1.Property<decimal>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("DiscountValue");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.OwnsOne("ERP.POS.Domain.Entities.OwnedEntities.Extra", "Extra", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Ratio")
                                .HasColumnType("REAL")
                                .HasColumnName("ExtraRatio");

                            b1.Property<decimal>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("ExtraValue");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Currency");

                    b.Navigation("Customer");

                    b.Navigation("Discount")
                        .IsRequired();

                    b.Navigation("Extra")
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.BillItem", b =>
                {
                    b.HasOne("ERP.POS.Domain.Entities.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ERP.POS.Domain.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ERP.POS.Domain.Entities.OwnedEntities.Discount", "Discount", b1 =>
                        {
                            b1.Property<Guid>("BillItemId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Ratio")
                                .HasColumnType("REAL")
                                .HasColumnName("DiscountRatio");

                            b1.Property<decimal>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("DiscountValue");

                            b1.HasKey("BillItemId");

                            b1.ToTable("BillItems");

                            b1.WithOwner()
                                .HasForeignKey("BillItemId");
                        });

                    b.OwnsOne("ERP.POS.Domain.Entities.OwnedEntities.Extra", "Extra", b1 =>
                        {
                            b1.Property<Guid>("BillItemId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Ratio")
                                .HasColumnType("REAL")
                                .HasColumnName("ExtraRatio");

                            b1.Property<decimal>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("ExtraValue");

                            b1.HasKey("BillItemId");

                            b1.ToTable("BillItems");

                            b1.WithOwner()
                                .HasForeignKey("BillItemId");
                        });

                    b.OwnsOne("ERP.POS.Domain.Entities.OwnedEntities.Measurement", "Measurement", b1 =>
                        {
                            b1.Property<Guid>("BillItemId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("UnitValue")
                                .HasColumnType("REAL");

                            b1.HasKey("BillItemId");

                            b1.ToTable("BillItems");

                            b1.WithOwner()
                                .HasForeignKey("BillItemId");
                        });

                    b.Navigation("Bill");

                    b.Navigation("Discount")
                        .IsRequired();

                    b.Navigation("Extra")
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Measurement")
                        .IsRequired();
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.CustomerBranch", b =>
                {
                    b.HasOne("ERP.POS.Domain.Entities.Customer", "Customer")
                        .WithMany("CustomerBranches")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("ERP.POS.Domain.Entities.Customer", b =>
                {
                    b.Navigation("CustomerBranches");
                });
#pragma warning restore 612, 618
        }
    }
}
