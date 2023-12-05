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
                    GroupName = table.Column<string>(type: "text", nullable: false)
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
                    BeerLoverEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEERLOVERS", x => x.BeerLoverID);
                });

            migrationBuilder.CreateTable(
                name: "BEERS",
                columns: table => new
                {
                    BeerID = table.Column<Guid>(type: "uuid", nullable: false),
                    BeerName = table.Column<string>(type: "text", nullable: false),
                    BeerType = table.Column<int>(type: "integer", nullable: false),
                    AleSubType = table.Column<int>(type: "integer", nullable: true),
                    LagerSubType = table.Column<int>(type: "integer", nullable: true),
                    SpecialtyHybridSubType = table.Column<int>(type: "integer", nullable: true),
                    StrongAleSubType = table.Column<int>(type: "integer", nullable: true),
                    Brewery = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEERS", x => x.BeerID);
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
                columns: new[] { "BeerGroupID", "GroupName" },
                values: new object[,]
                {
                    { new Guid("5035ab47-01e7-421d-8005-e6d88d68aed0"), "New Beer Enthusiasts" },
                    { new Guid("924f2e6d-9b35-42b4-b0ca-fcb8e68661e8"), "Craft Beer Enthusiasts" },
                    { new Guid("9a1e9eb5-cbe0-45ab-92b2-abc11d47a3cf"), "Stout Beer Enthusiasts" },
                    { new Guid("c462541f-74e9-4e14-b9c0-6cdc21d29719"), "IPA Beer Enthusiasts" },
                    { new Guid("cc59d1dc-a80b-41b1-bbc7-07a2ed37b9e9"), "Test Beer Enthusiasts" },
                    { new Guid("ce12aacb-2102-4932-8398-b9a48a05f3f0"), "Ale Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName" },
                values: new object[,]
                {
                    { new Guid("285d9d65-92a4-4df8-97d8-b547cc0f4ae8"), "Dask@example.com", "Dask Doe" },
                    { new Guid("6e2ae9f4-440b-49d0-acd3-2f9eb62657d0"), "Lope@example.com", "Lope Doe" },
                    { new Guid("78f6180b-cf2d-4c4f-8173-404848c5058d"), "Casper@example.com", "Casper Doe" },
                    { new Guid("d4935d0d-4c56-405e-b917-29d79695a4c7"), "Peter@example.com", "Peter Doe" },
                    { new Guid("dc63d46e-6aed-42d5-a1a5-a454c46b6d7c"), "Gope@example.com", "Gope Doe" },
                    { new Guid("e59b2ef2-69f8-4d47-a816-3fdb0b37a8fb"), "john@example.com", "John Doe" },
                    { new Guid("f13df107-dd13-404a-b18d-71c1bee80550"), "Joson@example.com", "Joson Doe" },
                    { new Guid("f4defc90-860b-4d6f-8136-bb23aab7b536"), "Jason@example.com", "Jason Doe" },
                    { new Guid("fe423505-e0f7-430a-9077-679f2ccd9285"), "Pop@example.com", "Pop Doe" }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerName", "BeerType", "Brewery", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("07470cef-a99b-4c28-9b9b-67977dc4aff6"), null, "Carlsberg pilsner", 1, "Carlsberg Brewery", 0, null, null },
                    { new Guid("5ba39c0c-d3e6-42b9-820a-2e2afcc83309"), null, "Grimberger double amber", 1, "Grimberger Brewery", 3, null, null },
                    { new Guid("603fc4ce-0083-442b-ad4f-bafd5de4773a"), 1, "IPA london", 0, "London Brewing Co", null, null, null },
                    { new Guid("712d58ea-f1c7-4edf-9233-b63769380c09"), null, "Anakisten bluberry", 2, "Anakisten Brewing", null, 0, null },
                    { new Guid("8098c989-62c2-40e8-a856-b325fe7d65f8"), 0, "Geuss new", 0, "Geuss Brewery", null, null, null },
                    { new Guid("a26c6d32-3120-435f-8e5f-7a19ca290568"), null, "Trapist lakrids", 3, "Trapist Brews", null, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerGroupModelBeerLoverModel_GroupMembersBeerLoverID",
                table: "BeerGroupModelBeerLoverModel",
                column: "GroupMembersBeerLoverID");

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
                name: "BEERLOVERS");

            migrationBuilder.DropTable(
                name: "BEERS");
        }
    }
}
