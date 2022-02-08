﻿// <auto-generated />
using System;
using CBMS.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CBMS.DAL.Migrations
{
    [DbContext(typeof(CityBusManagementDbContext))]
    [Migration("20220208050804_CRCreation")]
    partial class CRCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusStopRouteDetails", b =>
                {
                    b.Property<int>("busStopNo")
                        .HasColumnType("int");

                    b.Property<int>("routeDetailsrouteNo")
                        .HasColumnType("int");

                    b.HasKey("busStopNo", "routeDetailsrouteNo");

                    b.HasIndex("routeDetailsrouteNo");

                    b.ToTable("BusStopRouteDetails");
                });

            modelBuilder.Entity("CBMS.Entity.Model.BusDetails", b =>
                {
                    b.Property<int>("busNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("arrivalTime")
                        .HasColumnType("int");

                    b.Property<string>("busName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("busNo");

                    b.ToTable("busdetails");
                });

            modelBuilder.Entity("CBMS.Entity.Model.BusStop", b =>
                {
                    b.Property<int>("busStopNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("arrivalTime")
                        .HasColumnType("int");

                    b.Property<int>("depatureTime")
                        .HasColumnType("int");

                    b.Property<string>("stopName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("busStopNo");

                    b.ToTable("busstop");
                });

            modelBuilder.Entity("CBMS.Entity.Model.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("empName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tripDetailstripId")
                        .HasColumnType("int");

                    b.HasKey("empId");

                    b.HasIndex("tripDetailstripId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("CBMS.Entity.Model.RouteDetails", b =>
                {
                    b.Property<int>("routeNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("routeNo");

                    b.ToTable("routedetails");
                });

            modelBuilder.Entity("CBMS.Entity.Model.Trip", b =>
                {
                    b.Property<int>("tripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("busDetailsbusNo")
                        .HasColumnType("int");

                    b.Property<int?>("routeDetailsrouteNo")
                        .HasColumnType("int");

                    b.Property<int>("tripCount")
                        .HasColumnType("int");

                    b.HasKey("tripId");

                    b.HasIndex("busDetailsbusNo");

                    b.HasIndex("routeDetailsrouteNo");

                    b.ToTable("trip");
                });

            modelBuilder.Entity("BusStopRouteDetails", b =>
                {
                    b.HasOne("CBMS.Entity.Model.BusStop", null)
                        .WithMany()
                        .HasForeignKey("busStopNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBMS.Entity.Model.RouteDetails", null)
                        .WithMany()
                        .HasForeignKey("routeDetailsrouteNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBMS.Entity.Model.Employee", b =>
                {
                    b.HasOne("CBMS.Entity.Model.Trip", "tripDetails")
                        .WithMany("employeeDetails")
                        .HasForeignKey("tripDetailstripId");

                    b.Navigation("tripDetails");
                });

            modelBuilder.Entity("CBMS.Entity.Model.Trip", b =>
                {
                    b.HasOne("CBMS.Entity.Model.BusDetails", "busDetails")
                        .WithMany("trip")
                        .HasForeignKey("busDetailsbusNo");

                    b.HasOne("CBMS.Entity.Model.RouteDetails", "routeDetails")
                        .WithMany("trip")
                        .HasForeignKey("routeDetailsrouteNo");

                    b.Navigation("busDetails");

                    b.Navigation("routeDetails");
                });

            modelBuilder.Entity("CBMS.Entity.Model.BusDetails", b =>
                {
                    b.Navigation("trip");
                });

            modelBuilder.Entity("CBMS.Entity.Model.RouteDetails", b =>
                {
                    b.Navigation("trip");
                });

            modelBuilder.Entity("CBMS.Entity.Model.Trip", b =>
                {
                    b.Navigation("employeeDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
