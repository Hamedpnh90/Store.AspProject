﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.AspProject.DataLayer.Context;

#nullable disable

namespace Store.AspProject.Migrations
{
    [DbContext(typeof(AspStoreDbContext))]
    [Migration("20230726234418_edituser")]
    partial class edituser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Order.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<int>("orderSum")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Order.OrderDetails", b =>
                {
                    b.Property<int>("DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailsId"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Product.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductHeadTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("ProductId");

                    b.HasIndex("GroupId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Product.ProductGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GroupId");

                    b.ToTable("productGroups");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.user.user", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Rememberme")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserMobile")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("User_ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Order.Order", b =>
                {
                    b.HasOne("Store.AspProject.DataLayer.Models.user.user", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Order.OrderDetails", b =>
                {
                    b.HasOne("Store.AspProject.DataLayer.Models.Order.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.AspProject.DataLayer.Models.Product.Product", "product")
                        .WithMany("orderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Product.Product", b =>
                {
                    b.HasOne("Store.AspProject.DataLayer.Models.Product.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Order.Order", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Product.Product", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.Product.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Store.AspProject.DataLayer.Models.user.user", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
