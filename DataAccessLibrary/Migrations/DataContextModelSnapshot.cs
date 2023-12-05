﻿// <auto-generated />
using System;
using DataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BeerGroupModelBeerLoverModel", b =>
                {
                    b.Property<Guid>("BeerGroupsBeerGroupID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupMembersBeerLoverID")
                        .HasColumnType("uuid");

                    b.HasKey("BeerGroupsBeerGroupID", "GroupMembersBeerLoverID");

                    b.HasIndex("GroupMembersBeerLoverID");

                    b.ToTable("BeerGroupModelBeerLoverModel");
                });

            modelBuilder.Entity("ModelLibrary.BeerGroupModel", b =>
                {
                    b.Property<Guid>("BeerGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BeerGroupID");

                    b.ToTable("BEERGROUPS");

                    b.HasData(
                        new
                        {
                            BeerGroupID = new Guid("c2b4fab6-24a5-4e5b-b5f9-97110595cfb8"),
                            GroupName = "Craft Beer Enthusiasts"
                        },
                        new
                        {
                            BeerGroupID = new Guid("1bd214e5-2246-4472-afc8-bf11d96837dd"),
                            GroupName = "Ale Beer Enthusiasts"
                        },
                        new
                        {
                            BeerGroupID = new Guid("ab7c937b-32a4-401d-a306-a0014eb08179"),
                            GroupName = "Stout Beer Enthusiasts"
                        });
                });

            modelBuilder.Entity("ModelLibrary.BeerLoverModel", b =>
                {
                    b.Property<Guid>("BeerLoverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BeerLoverEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BeerLoverName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BeerLoverID");

                    b.ToTable("BEERLOVERS");

                    b.HasData(
                        new
                        {
                            BeerLoverID = new Guid("c7e1f65d-dd75-4ae6-a92c-677bd8ef44b6"),
                            BeerLoverEmail = "john@example.com",
                            BeerLoverName = "John Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("ac088d0f-2f64-405f-ae65-d5500704cfe9"),
                            BeerLoverEmail = "Pop@example.com",
                            BeerLoverName = "Pop Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("8aebcbbf-a91f-48c9-9775-041592f2afc4"),
                            BeerLoverEmail = "Joson@example.com",
                            BeerLoverName = "Joson Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("f83c98e6-01e8-4d88-a9ba-3fbc67f4b6c9"),
                            BeerLoverEmail = "Jason@example.com",
                            BeerLoverName = "Jason Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("7be021ff-c7f2-4fa6-b23a-1783b1984375"),
                            BeerLoverEmail = "Casper@example.com",
                            BeerLoverName = "Casper Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("e005ab7e-d718-452c-8c9d-5055393889c2"),
                            BeerLoverEmail = "Peter@example.com",
                            BeerLoverName = "Peter Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("04de221c-6523-4f80-bf06-d3e773ed72b5"),
                            BeerLoverEmail = "Dask@example.com",
                            BeerLoverName = "Dask Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("b1e27ee7-3026-4370-8ea5-a1cdd77df599"),
                            BeerLoverEmail = "Lope@example.com",
                            BeerLoverName = "Lope Doe"
                        },
                        new
                        {
                            BeerLoverID = new Guid("e1604353-59c9-43c8-9902-a43fbbf9593a"),
                            BeerLoverEmail = "Gope@example.com",
                            BeerLoverName = "Gope Doe"
                        });
                });

            modelBuilder.Entity("ModelLibrary.BeerModel", b =>
                {
                    b.Property<Guid>("BeerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AleSubType")
                        .HasColumnType("integer");

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BeerType")
                        .HasColumnType("integer");

                    b.Property<string>("Brewery")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LagerSubType")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecialtyHybridSubType")
                        .HasColumnType("integer");

                    b.Property<int?>("StrongAleSubType")
                        .HasColumnType("integer");

                    b.HasKey("BeerID");

                    b.ToTable("BEERS");

                    b.HasData(
                        new
                        {
                            BeerID = new Guid("7ce0c3c9-e7f9-434d-a385-441fd0316685"),
                            AleSubType = 0,
                            BeerName = "Geuss new",
                            BeerType = 0,
                            Brewery = "Geuss Brewery"
                        },
                        new
                        {
                            BeerID = new Guid("26c33056-6bdf-4a60-8f91-1765bfa3c055"),
                            AleSubType = 1,
                            BeerName = "IPA london",
                            BeerType = 0,
                            Brewery = "London Brewing Co"
                        },
                        new
                        {
                            BeerID = new Guid("f6b4825e-a1fc-45e8-8fb8-c56064ee25a4"),
                            BeerName = "Grimberger double amber",
                            BeerType = 1,
                            Brewery = "Grimberger Brewery",
                            LagerSubType = 3
                        },
                        new
                        {
                            BeerID = new Guid("81391768-6642-46cb-bcaf-674bdc535c3d"),
                            BeerName = "Anakisten bluberry",
                            BeerType = 2,
                            Brewery = "Anakisten Brewing",
                            SpecialtyHybridSubType = 0
                        },
                        new
                        {
                            BeerID = new Guid("92f8265d-afea-457e-a67e-b8d9a2fa392f"),
                            BeerName = "Trapist lakrids",
                            BeerType = 3,
                            Brewery = "Trapist Brews",
                            StrongAleSubType = 0
                        },
                        new
                        {
                            BeerID = new Guid("8105e013-fafc-401f-9c7a-4243b84e04cb"),
                            BeerName = "Carlsberg pilsner",
                            BeerType = 1,
                            Brewery = "Carlsberg Brewery",
                            LagerSubType = 0
                        });
                });

            modelBuilder.Entity("ModelLibrary.RatingModel", b =>
                {
                    b.Property<Guid>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BeerID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RatingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("RatingScore")
                        .HasColumnType("double precision");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<Guid>("TasterBeerLoverID")
                        .HasColumnType("uuid");

                    b.HasKey("RatingID");

                    b.HasIndex("BeerID");

                    b.HasIndex("TasterBeerLoverID");

                    b.ToTable("RATINGS");
                });

            modelBuilder.Entity("BeerGroupModelBeerLoverModel", b =>
                {
                    b.HasOne("ModelLibrary.BeerGroupModel", null)
                        .WithMany()
                        .HasForeignKey("BeerGroupsBeerGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLibrary.BeerLoverModel", null)
                        .WithMany()
                        .HasForeignKey("GroupMembersBeerLoverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModelLibrary.RatingModel", b =>
                {
                    b.HasOne("ModelLibrary.BeerModel", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLibrary.BeerLoverModel", "Taster")
                        .WithMany("rating")
                        .HasForeignKey("TasterBeerLoverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Taster");
                });

            modelBuilder.Entity("ModelLibrary.BeerLoverModel", b =>
                {
                    b.Navigation("rating");
                });

            modelBuilder.Entity("ModelLibrary.BeerModel", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
