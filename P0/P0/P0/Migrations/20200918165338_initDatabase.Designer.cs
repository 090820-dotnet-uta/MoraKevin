﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P0;

namespace P0.Migrations
{
    [DbContext(typeof(P0Context))]
    [Migration("20200918165338_initDatabase")]
    partial class initDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P0.Models.Billing", b =>
                {
                    b.Property<int>("BillingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressNum")
                        .HasColumnType("int");

                    b.Property<string>("AddressState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressZipCode")
                        .HasColumnType("int");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationYear")
                        .HasColumnType("int");

                    b.Property<string>("NameOnCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("int");

                    b.HasKey("BillingID");

                    b.ToTable("BillingInformation");
                });

            modelBuilder.Entity("P0.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("P0.Models.CustomerBilling", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("BillingID")
                        .HasColumnType("int");

                    b.Property<string>("Main")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID", "BillingID");

                    b.HasIndex("BillingID")
                        .IsUnique();

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.ToTable("CustomersBilling");
                });

            modelBuilder.Entity("P0.Models.CustomerShipping", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("ShippingID")
                        .HasColumnType("int");

                    b.Property<string>("Main")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID", "ShippingID");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.HasIndex("ShippingID")
                        .IsUnique();

                    b.ToTable("CustomersShipping");
                });

            modelBuilder.Entity("P0.Models.DefaultLocation", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID", "LocationID");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.HasIndex("LocationID")
                        .IsUnique();

                    b.ToTable("DefaultLocations");
                });

            modelBuilder.Entity("P0.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressNum")
                        .HasColumnType("int");

                    b.Property<string>("AddressState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressZipCode")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("P0.Models.LocationProducts", b =>
                {
                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.HasKey("LocationID", "ProductID");

                    b.HasIndex("LocationID")
                        .IsUnique();

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("LocationProducts");
                });

            modelBuilder.Entity("P0.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("OrderTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.HasIndex("LocationID")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("P0.Models.OrderProducts", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("P0.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("P0.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressNum")
                        .HasColumnType("int");

                    b.Property<string>("AddressState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressZipCode")
                        .HasColumnType("int");

                    b.HasKey("ShippingID");

                    b.ToTable("ShippingInformation");
                });

            modelBuilder.Entity("P0.Models.UserAccount", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.HasIndex("CustomerID");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("P0.Models.CustomerBilling", b =>
                {
                    b.HasOne("P0.Models.Billing", "Billing")
                        .WithOne("CustomerBilling")
                        .HasForeignKey("P0.Models.CustomerBilling", "BillingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Customer", "Customer")
                        .WithOne("CustomerBilling")
                        .HasForeignKey("P0.Models.CustomerBilling", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.CustomerShipping", b =>
                {
                    b.HasOne("P0.Models.Customer", "Customer")
                        .WithOne("CustomerShipping")
                        .HasForeignKey("P0.Models.CustomerShipping", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Shipping", "Shipping")
                        .WithOne("CustomerShipping")
                        .HasForeignKey("P0.Models.CustomerShipping", "ShippingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.DefaultLocation", b =>
                {
                    b.HasOne("P0.Models.Customer", "Customer")
                        .WithOne("DefaultLocation")
                        .HasForeignKey("P0.Models.DefaultLocation", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Location", "Location")
                        .WithOne("DefaultLocation")
                        .HasForeignKey("P0.Models.DefaultLocation", "LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.LocationProducts", b =>
                {
                    b.HasOne("P0.Models.Location", "Location")
                        .WithOne("LocationProducts")
                        .HasForeignKey("P0.Models.LocationProducts", "LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Product", "Product")
                        .WithOne("LocationProducts")
                        .HasForeignKey("P0.Models.LocationProducts", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.Order", b =>
                {
                    b.HasOne("P0.Models.Customer", "Customer")
                        .WithOne("Order")
                        .HasForeignKey("P0.Models.Order", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Location", "Location")
                        .WithOne("Order")
                        .HasForeignKey("P0.Models.Order", "LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.OrderProducts", b =>
                {
                    b.HasOne("P0.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0.Models.Product", "Product")
                        .WithOne("OrderProducts")
                        .HasForeignKey("P0.Models.OrderProducts", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P0.Models.UserAccount", b =>
                {
                    b.HasOne("P0.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
