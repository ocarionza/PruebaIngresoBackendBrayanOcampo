﻿// <auto-generated />
using System;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(NewshoreAirDbContext))]
    [Migration("20240304030856_NewshoreAir")]
    partial class NewshoreAir
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Repository.Models.Fligth", b =>
                {
                    b.Property<int>("FligthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fligth_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FligthId"));

                    b.Property<string>("Destination")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("destination");

                    b.Property<string>("Origin")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("origin");

                    b.Property<double?>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("TransportId")
                        .HasColumnType("int")
                        .HasColumnName("transport_id");

                    b.HasKey("FligthId");

                    b.HasIndex("TransportId");

                    b.ToTable("fligth");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Journey", b =>
                {
                    b.Property<int>("JourneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("journey_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JourneyId"));

                    b.Property<string>("Destination")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("destination");

                    b.Property<string>("Origin")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("origin");

                    b.Property<double?>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.HasKey("JourneyId");

                    b.ToTable("journey");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.JourneyFlight", b =>
                {
                    b.Property<int>("JourneyFlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("journey_flight_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JourneyFlightId"));

                    b.Property<int>("FligthId")
                        .HasColumnType("int")
                        .HasColumnName("fligth_id");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int")
                        .HasColumnName("journey_id");

                    b.HasKey("JourneyFlightId");

                    b.HasIndex("FligthId");

                    b.HasIndex("JourneyId");

                    b.ToTable("journey_flight");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Transport", b =>
                {
                    b.Property<int>("TransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("transport_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransportId"));

                    b.Property<string>("FligthCarrier")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fligth_carrier");

                    b.Property<string>("FligthCarrierNumber")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fligth_carrier_number");

                    b.HasKey("TransportId");

                    b.ToTable("transport");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Fligth", b =>
                {
                    b.HasOne("DataAccess.Repository.Models.Transport", "Transport")
                        .WithMany("Fligths")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.JourneyFlight", b =>
                {
                    b.HasOne("DataAccess.Repository.Models.Fligth", "Fligth")
                        .WithMany("JourneyFlights")
                        .HasForeignKey("FligthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Repository.Models.Journey", "Journey")
                        .WithMany("JourneyFlights")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fligth");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Fligth", b =>
                {
                    b.Navigation("JourneyFlights");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Journey", b =>
                {
                    b.Navigation("JourneyFlights");
                });

            modelBuilder.Entity("DataAccess.Repository.Models.Transport", b =>
                {
                    b.Navigation("Fligths");
                });
#pragma warning restore 612, 618
        }
    }
}