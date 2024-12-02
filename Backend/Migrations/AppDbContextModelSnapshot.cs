﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Data.PendingLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<bool>("Requester")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.HasIndex("VendorId");

                    b.ToTable("PendingLogs");
                });

            modelBuilder.Entity("Backend.Data.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("VendorId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("Backend.Data.ServiceProviderServiceLink", b =>
                {
                    b.Property<int>("ServiceVendorId")
                        .HasColumnType("integer");

                    b.Property<int>("VendorServiceId")
                        .HasColumnType("integer");

                    b.HasKey("ServiceVendorId", "VendorServiceId");

                    b.HasIndex("VendorServiceId");

                    b.ToTable("ServiceProviderServiceLinks");
                });

            modelBuilder.Entity("Backend.Data.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Iscompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("RequestedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceRequests");
                });

            modelBuilder.Entity("Backend.Data.ServiceVendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnicNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<int>("TotalOrders")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalRevenue")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("ServiceVendors");
                });

            modelBuilder.Entity("Backend.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnicNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<int>("TotalOrders")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Data.VendorService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrdersCount")
                        .HasColumnType("integer");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VendorServices");
                });

            modelBuilder.Entity("Backend.Data.PendingLog", b =>
                {
                    b.HasOne("Backend.Data.ServiceRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.ServiceVendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Backend.Data.ServiceOrder", b =>
                {
                    b.HasOne("Backend.Data.ServiceRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.ServiceVendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Backend.Data.ServiceProviderServiceLink", b =>
                {
                    b.HasOne("Backend.Data.ServiceVendor", "ServiceVendor")
                        .WithMany("ServiceProviderServiceLinks")
                        .HasForeignKey("ServiceVendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.VendorService", "VendorService")
                        .WithMany("ServiceProviderServiceLinks")
                        .HasForeignKey("VendorServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceVendor");

                    b.Navigation("VendorService");
                });

            modelBuilder.Entity("Backend.Data.ServiceRequest", b =>
                {
                    b.HasOne("Backend.Data.VendorService", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Data.ServiceVendor", b =>
                {
                    b.Navigation("ServiceProviderServiceLinks");
                });

            modelBuilder.Entity("Backend.Data.VendorService", b =>
                {
                    b.Navigation("ServiceProviderServiceLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
