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
                    b.Property<Guid>("BeerGroupID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupMemberBeerLoverID")
                        .HasColumnType("uuid");

                    b.HasKey("BeerGroupID", "GroupMemberBeerLoverID");

                    b.HasIndex("GroupMemberBeerLoverID");

                    b.ToTable("BeerGroupModelBeerLoverModel");
                });

            modelBuilder.Entity("ModelLibrary.BeerGroupModel", b =>
                {
                    b.Property<Guid>("BeerGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("GroupImage")
                        .HasColumnType("bytea");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BeerGroupID");

                    b.ToTable("BEERGROUPS");

                    b.HasData(
                        new
                        {
                            BeerGroupID = new Guid("93187833-db2e-41a3-a150-c1d6bc1918e1"),
                            GroupName = "Hop Heads"
                        },
                        new
                        {
                            BeerGroupID = new Guid("0fdf19ae-d4ac-47b2-9404-a3998b48fd77"),
                            GroupName = "Malty Crew"
                        },
                        new
                        {
                            BeerGroupID = new Guid("730b86a1-7e9e-4e0c-ae02-c6de9fc56f29"),
                            GroupName = "Yeasty Boys"
                        },
                        new
                        {
                            BeerGroupID = new Guid("ec48bf9c-c080-44f2-be55-676db2dae65b"),
                            GroupName = "Hoppy Hour Heroes"
                        },
                        new
                        {
                            BeerGroupID = new Guid("2a2a5123-4537-4536-a66a-105160fdce31"),
                            GroupName = "Fermentation Nation"
                        },
                        new
                        {
                            BeerGroupID = new Guid("a589528c-fa58-4a57-8ef0-6c268f62cc92"),
                            GroupName = "Ale Advocates"
                        },
                        new
                        {
                            BeerGroupID = new Guid("ff7248a2-165c-491e-b284-22ac33f71cad"),
                            GroupName = "Lager Lovers"
                        },
                        new
                        {
                            BeerGroupID = new Guid("04d31307-3dee-4881-a48d-6855012855dd"),
                            GroupName = "Stout Squad"
                        },
                        new
                        {
                            BeerGroupID = new Guid("95d0fb77-6bd0-411f-97ce-1e60f2961e56"),
                            GroupName = "Pilsner Posse"
                        },
                        new
                        {
                            BeerGroupID = new Guid("d6ce914b-b13f-4c47-aef1-73c67cfd1188"),
                            GroupName = "Sour Society"
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

                    b.Property<byte[]>("ProfilePic")
                        .HasColumnType("bytea");

                    b.HasKey("BeerLoverID");

                    b.ToTable("BEERLOVERS");

                    b.HasData(
                        new
                        {
                            BeerLoverID = new Guid("7a92bfdc-534c-4202-bbd2-ad19c44e7b71"),
                            BeerLoverEmail = "fizzmchopps@example.com",
                            BeerLoverName = "Fizz McHopps"
                        },
                        new
                        {
                            BeerLoverID = new Guid("cc99dd93-4613-4499-82ee-3b0457a6f2c2"),
                            BeerLoverEmail = "brewstervondrink@example.com",
                            BeerLoverName = "Brewster VonDrinkenstein"
                        },
                        new
                        {
                            BeerLoverID = new Guid("b7e89bd9-1557-4f68-bcca-aa44433693ae"),
                            BeerLoverEmail = "hoppymcbrew@example.com",
                            BeerLoverName = "Hoppy McBrewface"
                        },
                        new
                        {
                            BeerLoverID = new Guid("e59733fb-0a3b-4866-8e5a-9ccae7920176"),
                            BeerLoverEmail = "stoutymcstout@example.com",
                            BeerLoverName = "Stouty McStoutface"
                        },
                        new
                        {
                            BeerLoverID = new Guid("08b2bccd-54e0-41f2-b1ac-36bfeb8c0fbb"),
                            BeerLoverEmail = "alejandro@example.com",
                            BeerLoverName = "Alejandro Cerveza"
                        },
                        new
                        {
                            BeerLoverID = new Guid("81d69068-fc7c-4b6f-9965-fe53d8c1bf09"),
                            BeerLoverEmail = "lagerthalager@example.com",
                            BeerLoverName = "Lagertha Lagerstein"
                        },
                        new
                        {
                            BeerLoverID = new Guid("34175d49-8993-4c03-96d1-fa0a6e750fbd"),
                            BeerLoverEmail = "hops@example.com",
                            BeerLoverName = "Hops Solo"
                        },
                        new
                        {
                            BeerLoverID = new Guid("1171c4e8-8ebb-40c4-aee4-be3d75ab9e2b"),
                            BeerLoverEmail = "barleydavidson@example.com",
                            BeerLoverName = "Barley Davidson"
                        },
                        new
                        {
                            BeerLoverID = new Guid("82679542-4201-4f4c-ac22-16f1ebc8990b"),
                            BeerLoverEmail = "bockybalboa@example.com",
                            BeerLoverName = "Bocky Balboa"
                        },
                        new
                        {
                            BeerLoverID = new Guid("c479fec8-b82c-4b81-85eb-7dab3f2f4cce"),
                            BeerLoverEmail = "brewbacca@example.com",
                            BeerLoverName = "Brewbacca"
                        });
                });

            modelBuilder.Entity("ModelLibrary.BeerModel", b =>
                {
                    b.Property<Guid>("BeerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("BeerImage")
                        .HasColumnType("bytea");

                    b.Property<Guid?>("BeerLoverModelBeerLoverID")
                        .HasColumnType("uuid");

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BeerType")
                        .HasColumnType("integer");

                    b.Property<Guid?>("BreweryID")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BeerID");

                    b.HasIndex("BeerLoverModelBeerLoverID");

                    b.HasIndex("BreweryID");

                    b.ToTable("BEERS");

                    b.HasData(
                        new
                        {
                            BeerID = new Guid("3f8a7176-c2bf-418f-bfb4-91c1c912c2b0"),
                            BeerName = "Carlsberg Pilsner",
                            BeerType = 0,
                            Description = "En klassisk dansk pilsner med en lys og forfriskende smag."
                        },
                        new
                        {
                            BeerID = new Guid("51981424-42a1-4b63-bee4-a6a16cf11e55"),
                            BeerName = "Tuborg Classic",
                            BeerType = 0,
                            Description = "En dansk pilsner med en fyldig krop og en let humlet finish."
                        },
                        new
                        {
                            BeerID = new Guid("039f6437-059b-494d-ac94-1bb5a528e2f6"),
                            BeerName = "Grimbergen Blonde",
                            BeerType = 2,
                            Description = "En belgisk ale med en gylden farve og en frugtagtig, krydret smag."
                        },
                        new
                        {
                            BeerID = new Guid("aa25d0c5-2384-418a-bdd7-a46875be34a9"),
                            BeerName = "Leffe blanch",
                            BeerType = 2,
                            Description = "En belgisk light ale med en lysbrun farve og en fyldig smag."
                        },
                        new
                        {
                            BeerID = new Guid("c6394522-140d-4b03-aa60-b1f78a52121d"),
                            BeerName = "Gulddame",
                            BeerType = 0,
                            Description = "Dansk indentitet."
                        },
                        new
                        {
                            BeerID = new Guid("0d5891d4-6894-4aae-8d5c-0a6bdf0bf28c"),
                            BeerName = "Duvel",
                            BeerType = 2,
                            Description = "En belgisk ale med en dyb brun farve og en fyldig smag af humle."
                        },
                        new
                        {
                            BeerID = new Guid("937f5b48-84d7-4aa3-bc50-d936bc2b2ca0"),
                            BeerName = "Trapist",
                            BeerType = 4,
                            Description = "En belgisk dark ale og en fyldig smag af frugt."
                        });
                });

            modelBuilder.Entity("ModelLibrary.BreweryModel", b =>
                {
                    b.Property<Guid>("BreweryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BeerLoverModelBeerLoverID")
                        .HasColumnType("uuid");

                    b.Property<string>("BreweryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BreweryID");

                    b.HasIndex("BeerLoverModelBeerLoverID");

                    b.ToTable("BREWERIES");

                    b.HasData(
                        new
                        {
                            BreweryID = new Guid("bdf518c1-c726-48a5-b697-a5b5d01e21b0"),
                            BreweryName = "Munich beer",
                            Country = "Germany"
                        },
                        new
                        {
                            BreweryID = new Guid("00780e56-95a4-4850-a23d-9b43e0d13881"),
                            BreweryName = "Carlsberg",
                            Country = "Denmark"
                        },
                        new
                        {
                            BreweryID = new Guid("b280e699-4b9f-4a1f-82be-864b6a74b47a"),
                            BreweryName = "Heineken",
                            Country = "Holland"
                        },
                        new
                        {
                            BreweryID = new Guid("ff14102c-21b8-4a14-9d14-537473405751"),
                            BreweryName = "Delerium",
                            Country = "Belgium"
                        },
                        new
                        {
                            BreweryID = new Guid("43441010-b014-41e1-aac3-55aaa51520ae"),
                            BreweryName = "Tuborg bryggeri",
                            Country = "Denmark"
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

                    b.Property<byte[]>("RatingImage")
                        .HasColumnType("bytea");

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
                        .HasForeignKey("BeerGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLibrary.BeerLoverModel", null)
                        .WithMany()
                        .HasForeignKey("GroupMemberBeerLoverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModelLibrary.BeerModel", b =>
                {
                    b.HasOne("ModelLibrary.BeerLoverModel", null)
                        .WithMany("FavBeer")
                        .HasForeignKey("BeerLoverModelBeerLoverID");

                    b.HasOne("ModelLibrary.BreweryModel", "Brewery")
                        .WithMany("ProducedBeer")
                        .HasForeignKey("BreweryID");

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("ModelLibrary.BreweryModel", b =>
                {
                    b.HasOne("ModelLibrary.BeerLoverModel", null)
                        .WithMany("FavBrewery")
                        .HasForeignKey("BeerLoverModelBeerLoverID");
                });

            modelBuilder.Entity("ModelLibrary.RatingModel", b =>
                {
                    b.HasOne("ModelLibrary.BeerModel", "Beer")
                        .WithMany("Rating")
                        .HasForeignKey("BeerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLibrary.BeerLoverModel", "Taster")
                        .WithMany("Rating")
                        .HasForeignKey("TasterBeerLoverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Taster");
                });

            modelBuilder.Entity("ModelLibrary.BeerLoverModel", b =>
                {
                    b.Navigation("FavBeer");

                    b.Navigation("FavBrewery");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("ModelLibrary.BeerModel", b =>
                {
                    b.Navigation("Rating");
                });

            modelBuilder.Entity("ModelLibrary.BreweryModel", b =>
                {
                    b.Navigation("ProducedBeer");
                });
#pragma warning restore 612, 618
        }
    }
}
