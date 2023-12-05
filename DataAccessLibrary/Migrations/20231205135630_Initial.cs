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
                    { new Guid("3e7b2959-ee1e-40c8-a173-eb930deaedc6"), "Stout Beer Enthusiasts" },
                    { new Guid("4041008e-ee42-404d-873f-7c51825c37fa"), "Test Beer Enthusiasts" },
                    { new Guid("5cbc2eac-498b-4745-adda-50450e80c5ed"), "IPA Beer Enthusiasts" },
                    { new Guid("6e9e20a6-6ae4-497e-81e4-0bb5a41fc1e9"), "Craft Beer Enthusiasts" },
                    { new Guid("dfa2eda8-361b-4fc7-9c6a-6cac9c32215e"), "New Beer Enthusiasts" },
                    { new Guid("eac27345-715f-48e3-97cf-2f2658475205"), "Ale Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName" },
                values: new object[,]
                {
                    { new Guid("281a05e8-afa2-4d20-a077-384350caee20"), "Joson@example.com", "Joson Doe" },
                    { new Guid("875c9a48-9df9-4553-a5a6-d709c673cb69"), "john@example.com", "John Doe" },
                    { new Guid("8a3bb6bc-d9cf-4198-8bce-2f9bc9948155"), "Casper@example.com", "Casper Doe" },
                    { new Guid("8c28cfe4-9c87-42bc-9eab-f2051e71aca6"), "Jason@example.com", "Jason Doe" },
                    { new Guid("a0f7363a-d51e-49c4-99af-9a46ebf7dda8"), "Peter@example.com", "Peter Doe" },
                    { new Guid("b474dc2a-66d4-438a-b9ba-8bf58a9d187d"), "Dask@example.com", "Dask Doe" },
                    { new Guid("d47f52d1-ea5f-4557-abcb-31c57ed2b5c5"), "Gope@example.com", "Gope Doe" },
                    { new Guid("ed3768c1-6053-4a7c-855f-5d9b634a70df"), "Pop@example.com", "Pop Doe" },
                    { new Guid("f75c7350-03da-4e0c-8a35-950e21168799"), "Lope@example.com", "Lope Doe" }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerName", "BeerType", "Brewery", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("17b75e7b-c621-4793-ba3e-45058f54fccf"), 0, "Geuss new", 0, "Geuss Brewery", null, null, null },
                    { new Guid("3b776763-921e-4174-94e9-9485a73a230c"), null, "Grimberger double amber", 1, "Grimberger Brewery", 3, null, null },
                    { new Guid("7d0f6055-0f22-4ee1-b480-eeebd7dc7cd5"), 1, "IPA london", 0, "London Brewing Co", null, null, null },
                    { new Guid("ae54d8df-8b6a-48b7-bc4b-df11c166c5e3"), null, "Carlsberg pilsner", 1, "Carlsberg Brewery", 0, null, null },
                    { new Guid("f2a9e081-edf8-4644-9e49-0a2c275576a0"), null, "Trapist lakrids", 3, "Trapist Brews", null, null, 0 },
                    { new Guid("f9a9833d-b2ef-412f-91ca-717755ff052b"), null, "Anakisten bluberry", 2, "Anakisten Brewing", null, 0, null }
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
