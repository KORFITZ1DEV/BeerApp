using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BEERGROUPS",
                columns: table => new
                {
                    BeerGroupID = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: false),
                    GroupImage = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEERGROUPS", x => x.BeerGroupID);
                });

            migrationBuilder.CreateTable(
                name: "BEERLOVERS",
                columns: table => new
                {
                    BeerLoverID = table.Column<Guid>(type: "uuid", nullable: false),
                    BeerLoverName = table.Column<string>(type: "text", nullable: false),
                    BeerLoverEmail = table.Column<string>(type: "text", nullable: false),
                    ProfilePic = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEERLOVERS", x => x.BeerLoverID);
                });

            migrationBuilder.CreateTable(
                name: "BeerGroupModelBeerLoverModel",
                columns: table => new
                {
                    BeerGroupID = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMemberBeerLoverID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerGroupModelBeerLoverModel", x => new { x.BeerGroupID, x.GroupMemberBeerLoverID });
                    table.ForeignKey(
                        name: "FK_BeerGroupModelBeerLoverModel_BEERGROUPS_BeerGroupID",
                        column: x => x.BeerGroupID,
                        principalTable: "BEERGROUPS",
                        principalColumn: "BeerGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerGroupModelBeerLoverModel_BEERLOVERS_GroupMemberBeerLove~",
                        column: x => x.GroupMemberBeerLoverID,
                        principalTable: "BEERLOVERS",
                        principalColumn: "BeerLoverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BREWERIES",
                columns: table => new
                {
                    BreweryID = table.Column<Guid>(type: "uuid", nullable: false),
                    BreweryName = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    BeerLoverModelBeerLoverID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BREWERIES", x => x.BreweryID);
                    table.ForeignKey(
                        name: "FK_BREWERIES_BEERLOVERS_BeerLoverModelBeerLoverID",
                        column: x => x.BeerLoverModelBeerLoverID,
                        principalTable: "BEERLOVERS",
                        principalColumn: "BeerLoverID");
                });

            migrationBuilder.CreateTable(
                name: "BEERS",
                columns: table => new
                {
                    BeerID = table.Column<Guid>(type: "uuid", nullable: false),
                    BeerName = table.Column<string>(type: "text", nullable: false),
                    BeerType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BreweryID = table.Column<Guid>(type: "uuid", nullable: true),
                    BeerImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    BeerLoverModelBeerLoverID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEERS", x => x.BeerID);
                    table.ForeignKey(
                        name: "FK_BEERS_BEERLOVERS_BeerLoverModelBeerLoverID",
                        column: x => x.BeerLoverModelBeerLoverID,
                        principalTable: "BEERLOVERS",
                        principalColumn: "BeerLoverID");
                    table.ForeignKey(
                        name: "FK_BEERS_BREWERIES_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "BREWERIES",
                        principalColumn: "BreweryID");
                });

            migrationBuilder.CreateTable(
                name: "RATINGS",
                columns: table => new
                {
                    RatingID = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingScore = table.Column<double>(type: "double precision", nullable: false),
                    BeerID = table.Column<Guid>(type: "uuid", nullable: false),
                    TasterBeerLoverID = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: true),
                    RatingImage = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATINGS", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_RATINGS_BEERLOVERS_TasterBeerLoverID",
                        column: x => x.TasterBeerLoverID,
                        principalTable: "BEERLOVERS",
                        principalColumn: "BeerLoverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RATINGS_BEERS_BeerID",
                        column: x => x.BeerID,
                        principalTable: "BEERS",
                        principalColumn: "BeerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BEERGROUPS",
                columns: new[] { "BeerGroupID", "GroupImage", "GroupName" },
                values: new object[,]
                {
                    { new Guid("04d31307-3dee-4881-a48d-6855012855dd"), null, "Stout Squad" },
                    { new Guid("0fdf19ae-d4ac-47b2-9404-a3998b48fd77"), null, "Malty Crew" },
                    { new Guid("2a2a5123-4537-4536-a66a-105160fdce31"), null, "Fermentation Nation" },
                    { new Guid("730b86a1-7e9e-4e0c-ae02-c6de9fc56f29"), null, "Yeasty Boys" },
                    { new Guid("93187833-db2e-41a3-a150-c1d6bc1918e1"), null, "Hop Heads" },
                    { new Guid("95d0fb77-6bd0-411f-97ce-1e60f2961e56"), null, "Pilsner Posse" },
                    { new Guid("a589528c-fa58-4a57-8ef0-6c268f62cc92"), null, "Ale Advocates" },
                    { new Guid("d6ce914b-b13f-4c47-aef1-73c67cfd1188"), null, "Sour Society" },
                    { new Guid("ec48bf9c-c080-44f2-be55-676db2dae65b"), null, "Hoppy Hour Heroes" },
                    { new Guid("ff7248a2-165c-491e-b284-22ac33f71cad"), null, "Lager Lovers" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName", "ProfilePic" },
                values: new object[,]
                {
                    { new Guid("08b2bccd-54e0-41f2-b1ac-36bfeb8c0fbb"), "alejandro@example.com", "Alejandro Cerveza", null },
                    { new Guid("1171c4e8-8ebb-40c4-aee4-be3d75ab9e2b"), "barleydavidson@example.com", "Barley Davidson", null },
                    { new Guid("34175d49-8993-4c03-96d1-fa0a6e750fbd"), "hops@example.com", "Hops Solo", null },
                    { new Guid("7a92bfdc-534c-4202-bbd2-ad19c44e7b71"), "fizzmchopps@example.com", "Fizz McHopps", null },
                    { new Guid("81d69068-fc7c-4b6f-9965-fe53d8c1bf09"), "lagerthalager@example.com", "Lagertha Lagerstein", null },
                    { new Guid("82679542-4201-4f4c-ac22-16f1ebc8990b"), "bockybalboa@example.com", "Bocky Balboa", null },
                    { new Guid("b7e89bd9-1557-4f68-bcca-aa44433693ae"), "hoppymcbrew@example.com", "Hoppy McBrewface", null },
                    { new Guid("c479fec8-b82c-4b81-85eb-7dab3f2f4cce"), "brewbacca@example.com", "Brewbacca", null },
                    { new Guid("cc99dd93-4613-4499-82ee-3b0457a6f2c2"), "brewstervondrink@example.com", "Brewster VonDrinkenstein", null },
                    { new Guid("e59733fb-0a3b-4866-8e5a-9ccae7920176"), "stoutymcstout@example.com", "Stouty McStoutface", null }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "BeerImage", "BeerLoverModelBeerLoverID", "BeerName", "BeerType", "BreweryID", "Description" },
                values: new object[,]
                {
                    { new Guid("039f6437-059b-494d-ac94-1bb5a528e2f6"), null, null, "Grimbergen Blonde", 2, null, "En belgisk ale med en gylden farve og en frugtagtig, krydret smag." },
                    { new Guid("0d5891d4-6894-4aae-8d5c-0a6bdf0bf28c"), null, null, "Duvel", 2, null, "En belgisk ale med en dyb brun farve og en fyldig smag af humle." },
                    { new Guid("3f8a7176-c2bf-418f-bfb4-91c1c912c2b0"), null, null, "Carlsberg Pilsner", 0, null, "En klassisk dansk pilsner med en lys og forfriskende smag." },
                    { new Guid("51981424-42a1-4b63-bee4-a6a16cf11e55"), null, null, "Tuborg Classic", 0, null, "En dansk pilsner med en fyldig krop og en let humlet finish." },
                    { new Guid("937f5b48-84d7-4aa3-bc50-d936bc2b2ca0"), null, null, "Trapist", 4, null, "En belgisk dark ale og en fyldig smag af frugt." },
                    { new Guid("aa25d0c5-2384-418a-bdd7-a46875be34a9"), null, null, "Leffe blanch", 2, null, "En belgisk light ale med en lysbrun farve og en fyldig smag." },
                    { new Guid("c6394522-140d-4b03-aa60-b1f78a52121d"), null, null, "Gulddame", 0, null, "Dansk indentitet." }
                });

            migrationBuilder.InsertData(
                table: "BREWERIES",
                columns: new[] { "BreweryID", "BeerLoverModelBeerLoverID", "BreweryName", "Country" },
                values: new object[,]
                {
                    { new Guid("00780e56-95a4-4850-a23d-9b43e0d13881"), null, "Carlsberg", "Denmark" },
                    { new Guid("43441010-b014-41e1-aac3-55aaa51520ae"), null, "Tuborg bryggeri", "Denmark" },
                    { new Guid("b280e699-4b9f-4a1f-82be-864b6a74b47a"), null, "Heineken", "Holland" },
                    { new Guid("bdf518c1-c726-48a5-b697-a5b5d01e21b0"), null, "Munich beer", "Germany" },
                    { new Guid("ff14102c-21b8-4a14-9d14-537473405751"), null, "Delerium", "Belgium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerGroupModelBeerLoverModel_GroupMemberBeerLoverID",
                table: "BeerGroupModelBeerLoverModel",
                column: "GroupMemberBeerLoverID");

            migrationBuilder.CreateIndex(
                name: "IX_BEERS_BeerLoverModelBeerLoverID",
                table: "BEERS",
                column: "BeerLoverModelBeerLoverID");

            migrationBuilder.CreateIndex(
                name: "IX_BEERS_BreweryID",
                table: "BEERS",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_BREWERIES_BeerLoverModelBeerLoverID",
                table: "BREWERIES",
                column: "BeerLoverModelBeerLoverID");

            migrationBuilder.CreateIndex(
                name: "IX_RATINGS_BeerID",
                table: "RATINGS",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_RATINGS_TasterBeerLoverID",
                table: "RATINGS",
                column: "TasterBeerLoverID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerGroupModelBeerLoverModel");

            migrationBuilder.DropTable(
                name: "RATINGS");

            migrationBuilder.DropTable(
                name: "BEERGROUPS");

            migrationBuilder.DropTable(
                name: "BEERS");

            migrationBuilder.DropTable(
                name: "BREWERIES");

            migrationBuilder.DropTable(
                name: "BEERLOVERS");
        }
    }
}
