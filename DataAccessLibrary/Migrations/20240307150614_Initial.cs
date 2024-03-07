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
                    { new Guid("8593a6a3-82e9-4ca2-9ce5-feecf1573097"), null, "Craft Beer Enthusiasts" },
                    { new Guid("91361e7d-8137-46b1-9178-865dc73fa7d4"), null, "New Beer Enthusiasts" },
                    { new Guid("bd3f7423-9c8c-4ded-9b0e-abda515a06dc"), null, "Stout Beer Enthusiasts" },
                    { new Guid("c4b38b9a-6daa-42f4-a85c-b5efba4a82dd"), null, "IPA Beer Enthusiasts" },
                    { new Guid("c608a24e-23a6-4783-ab27-1b44b229d5ae"), null, "Test Beer Enthusiasts" },
                    { new Guid("f3f197dd-5025-4e3e-a2ca-10af3332961f"), null, "Ale Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName", "ProfilePic" },
                values: new object[,]
                {
                    { new Guid("038a6e76-1f26-4370-bc24-d578af2ce3c2"), "Jason@example.com", "Jason Doe", null },
                    { new Guid("37161c1f-62d7-4258-a446-80de658ec92e"), "Lope@example.com", "Lope Doe", null },
                    { new Guid("3727add4-f4f7-4cd9-96a3-5f3ce55b3618"), "Peter@example.com", "Peter Doe", null },
                    { new Guid("3e16db90-c128-4e0f-9eb9-281dc2461b1c"), "Casper@example.com", "Casper Doe", null },
                    { new Guid("6ea640f4-b9bb-4ab6-80bf-90b9ef96f75c"), "Gope@example.com", "Gope Doe", null },
                    { new Guid("814bb73c-c33b-49df-bb32-b36626131c6b"), "Dask@example.com", "Dask Doe", null },
                    { new Guid("a79b372b-3f19-4f8e-8261-d578a9434d3f"), "Pop@example.com", "Pop Doe", null },
                    { new Guid("bd36a650-6390-4c20-bfc7-ea8634ce0ada"), "john@example.com", "John Doe", null },
                    { new Guid("e0c84540-c286-4037-81d9-f3c693827023"), "Joson@example.com", "Joson Doe", null }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "BeerImage", "BeerLoverModelBeerLoverID", "BeerName", "BeerType", "BreweryID", "Description" },
                values: new object[,]
                {
                    { new Guid("9f7a3b20-f17c-438b-a72c-40d683853b4f"), null, null, "Leffe Brune", 4, null, "En belgisk ale med en rødbrun farve og en fyldig smag af karamel og tørret frugt." },
                    { new Guid("b07772bd-f6c9-425d-ab1d-c9394416720c"), null, null, "Carlsberg Pilsner", 0, null, "En klassisk dansk pilsner med en lys og forfriskende smag." },
                    { new Guid("e59841c0-0e3d-4418-8b37-3be230ebebe3"), null, null, "Tuborg Classic", 0, null, "En dansk pilsner med en fyldig krop og en let humlet finish." },
                    { new Guid("e630f9a5-deb3-4efc-a726-c28d96f4027f"), null, null, "Grimbergen Blonde", 2, null, "En belgisk ale med en gylden farve og en frugtagtig, krydret smag." }
                });

            migrationBuilder.InsertData(
                table: "BREWERIES",
                columns: new[] { "BreweryID", "BeerLoverModelBeerLoverID", "BreweryName", "Country" },
                values: new object[,]
                {
                    { new Guid("15d82959-2105-425c-b6c3-a24cd694b3ea"), null, "Carlsberg", "Denmark" },
                    { new Guid("3babc6c6-8d55-4985-ae33-b1be0cd15408"), null, "Delerium", "Belgium" },
                    { new Guid("4fb47d6c-e110-48b5-b4ea-06a060ee5ee1"), null, "Munich Brewery", "Germany" }
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
