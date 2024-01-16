﻿// <auto-generated />
using System;
using HotelBookingAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelBookingAPI.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20240106075248_changes")]
    partial class changes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelBookingAPI.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("RoomSize")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("BookingId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("HotelBookingAPI.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HotelId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Ratings")
                        .HasColumnType("double precision");

                    b.Property<int>("TotalRooms")
                        .HasColumnType("integer");

                    b.HasKey("HotelId");

                    b.ToTable("hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 101,
                            Description = "Luxurious hotel with world-class amenities,food,and entertainment",
                            HotelName = "Paradise Hotel",
                            Location = "Pune",
                            Ratings = 4.5,
                            TotalRooms = 10
                        });
                });

            modelBuilder.Entity("HotelBookingAPI.Models.Rooms", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("RoomSize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoomNumber", "HotelId");

                    b.HasIndex("HotelId");

                    b.ToTable("rooms");

                    b.HasData(
                        new
                        {
                            RoomNumber = 1011,
                            HotelId = 101,
                            IsBooked = true,
                            Price = 1900.99,
                            RoomSize = "Suite"
                        },
                        new
                        {
                            RoomNumber = 1012,
                            HotelId = 101,
                            IsBooked = false,
                            Price = 970.99000000000001,
                            RoomSize = "Double"
                        },
                        new
                        {
                            RoomNumber = 1021,
                            HotelId = 102,
                            IsBooked = true,
                            Price = 570.99000000000001,
                            RoomSize = "Single"
                        },
                        new
                        {
                            RoomNumber = 1022,
                            HotelId = 102,
                            IsBooked = false,
                            Price = 2970.9899999999998,
                            RoomSize = "Suite"
                        },
                        new
                        {
                            RoomNumber = 1023,
                            HotelId = 102,
                            IsBooked = false,
                            Price = 1200.99,
                            RoomSize = "Luxury"
                        });
                });

            modelBuilder.Entity("HotelBookingAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<byte[]>("Key")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("HotelBookingAPI.Models.Booking", b =>
                {
                    b.HasOne("HotelBookingAPI.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBookingAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBookingAPI.Models.Rooms", b =>
                {
                    b.HasOne("HotelBookingAPI.Models.Hotel", "Hotel")
                        .WithMany("roomss")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelBookingAPI.Models.Hotel", b =>
                {
                    b.Navigation("roomss");
                });
#pragma warning restore 612, 618
        }
    }
}
