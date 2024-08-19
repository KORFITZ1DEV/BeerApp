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
                    BeerGroupsBeerGroupID = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMembersBeerLoverID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerGroupModelBeerLoverModel", x => new { x.BeerGroupsBeerGroupID, x.GroupMembersBeerLoverID });
                    table.ForeignKey(
                        name: "FK_BeerGroupModelBeerLoverModel_BEERGROUPS_BeerGroupsBeerGroup~",
                        column: x => x.BeerGroupsBeerGroupID,
                        principalTable: "BEERGROUPS",
                        principalColumn: "BeerGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerGroupModelBeerLoverModel_BEERLOVERS_GroupMembersBeerLov~",
                        column: x => x.GroupMembersBeerLoverID,
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
                    BreweryAddress = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
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
                    Description = table.Column<string>(type: "text", nullable: true),
                    AleSubType = table.Column<int>(type: "integer", nullable: true),
                    LagerSubType = table.Column<int>(type: "integer", nullable: true),
                    SpecialtyHybridSubType = table.Column<int>(type: "integer", nullable: true),
                    StrongAleSubType = table.Column<int>(type: "integer", nullable: true),
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
                    Review = table.Column<string>(type: "text", nullable: true)
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
                    { new Guid("02591354-80d4-4fdd-82ec-a3c5f1ba363b"), null, "Stout Beer Enthusiasts" },
                    { new Guid("5774303f-27b5-464c-a107-e278eb5a9b86"), null, "Ale Beer Enthusiasts" },
                    { new Guid("6a8a1dfc-e83e-45e6-87c1-f3dbf782e41f"), null, "New Beer Enthusiasts" },
                    { new Guid("85b6e4da-a3b1-47f7-8d6f-fd6c5a30f4bf"), null, "Craft Beer Enthusiasts" },
                    { new Guid("981abd86-3f97-495a-abaa-c79529f94881"), null, "IPA Beer Enthusiasts" },
                    { new Guid("d739ec83-d624-4659-8ca9-a5e974e9e5f0"), null, "Test Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName", "ProfilePic" },
                values: new object[,]
                {
                    { new Guid("74c52131-8ac3-4923-8cff-cbc5859f6c14"), "Peter@example.com", "Peter Doe", null },
                    { new Guid("7e533e81-2a89-4e6c-9678-39853bef209e"), "Casper@example.com", "Casper Doe", null },
                    { new Guid("8b4b664d-2325-4d8a-a340-f8deb5d1c463"), "john@example.com", "John Doe", null },
                    { new Guid("9928cfe4-c2e0-4463-8e8d-1c7a5e275ff0"), "Jason@example.com", "Jason Doe", null },
                    { new Guid("bbbbddcd-4307-486c-bc19-2019a3a98deb"), "Lope@example.com", "Lope Doe", null },
                    { new Guid("d05ff43d-408c-4777-85c5-68d2defd0070"), "Pop@example.com", "Pop Doe", null },
                    { new Guid("de9c0d03-767a-47e4-8bf7-a5b558bb7478"), "Gope@example.com", "Gope Doe", null },
                    { new Guid("e9c9acbd-45a1-4da9-8ca8-85462cb66241"), "Joson@example.com", "Joson Doe", null },
                    { new Guid("ea1da600-e9b2-49f3-b1a2-fa8a879c993d"), "Dask@example.com", "Dask Doe", null }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerImage", "BeerLoverModelBeerLoverID", "BeerName", "BeerType", "BreweryID", "Description", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("1c6bc689-cd71-436b-9f11-88dcc5617790"), 0, null, null, "Geuss new", 0, null, "", null, null, null },
                    { new Guid("3a0172bb-fc3c-4e7c-9fff-46db54752cef"), null, null, null, "Carlsberg pilsner", 1, null, "", 0, null, null },
                    { new Guid("477feaf9-3c7f-47ee-abbd-dfa7435c55e0"), null, null, null, "Grimberger double amber", 1, null, "", 3, null, null },
                    { new Guid("6c5d0208-d2ff-472e-9b35-1b857f61fa02"), 1, null, null, "IPA london", 0, null, "", null, null, null },
                    { new Guid("c918a343-a9af-46d8-876e-1c62b2221d75"), null, null, null, "Anakisten bluberry", 2, null, "", null, 0, null },
                    { new Guid("dc778984-e9f7-402a-9b19-766b304fdebd"), null, null, null, "Trapist lakrids", 3, null, "", null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "BREWERIES",
                columns: new[] { "BreweryID", "BeerLoverModelBeerLoverID", "BreweryAddress", "BreweryName", "Country" },
                values: new object[,]
                {
                    { new Guid("3b5ce26a-5cb4-48be-8ced-189186736f37"), null, "9838 Vestrebro København NW", "Tuborg", "DK" },
                    { new Guid("70326e49-102e-4029-8879-6f69879fb56b"), null, "9090 Brussels NW", "Leffe", "BL" },
                    { new Guid("9d1ab566-4529-4baa-b0d2-2672be17a68c"), null, "9838 Østrebro København SW", "Carlsberg", "DK" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerGroupModelBeerLoverModel_GroupMembersBeerLoverID",
                table: "BeerGroupModelBeerLoverModel",
                column: "GroupMembersBeerLoverID");

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
