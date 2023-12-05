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
                    { new Guid("1bd214e5-2246-4472-afc8-bf11d96837dd"), "Ale Beer Enthusiasts" },
                    { new Guid("ab7c937b-32a4-401d-a306-a0014eb08179"), "Stout Beer Enthusiasts" },
                    { new Guid("c2b4fab6-24a5-4e5b-b5f9-97110595cfb8"), "Craft Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName" },
                values: new object[,]
                {
                    { new Guid("04de221c-6523-4f80-bf06-d3e773ed72b5"), "Dask@example.com", "Dask Doe" },
                    { new Guid("7be021ff-c7f2-4fa6-b23a-1783b1984375"), "Casper@example.com", "Casper Doe" },
                    { new Guid("8aebcbbf-a91f-48c9-9775-041592f2afc4"), "Joson@example.com", "Joson Doe" },
                    { new Guid("ac088d0f-2f64-405f-ae65-d5500704cfe9"), "Pop@example.com", "Pop Doe" },
                    { new Guid("b1e27ee7-3026-4370-8ea5-a1cdd77df599"), "Lope@example.com", "Lope Doe" },
                    { new Guid("c7e1f65d-dd75-4ae6-a92c-677bd8ef44b6"), "john@example.com", "John Doe" },
                    { new Guid("e005ab7e-d718-452c-8c9d-5055393889c2"), "Peter@example.com", "Peter Doe" },
                    { new Guid("e1604353-59c9-43c8-9902-a43fbbf9593a"), "Gope@example.com", "Gope Doe" },
                    { new Guid("f83c98e6-01e8-4d88-a9ba-3fbc67f4b6c9"), "Jason@example.com", "Jason Doe" }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerName", "BeerType", "Brewery", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("26c33056-6bdf-4a60-8f91-1765bfa3c055"), 1, "IPA london", 0, "London Brewing Co", null, null, null },
                    { new Guid("7ce0c3c9-e7f9-434d-a385-441fd0316685"), 0, "Geuss new", 0, "Geuss Brewery", null, null, null },
                    { new Guid("8105e013-fafc-401f-9c7a-4243b84e04cb"), null, "Carlsberg pilsner", 1, "Carlsberg Brewery", 0, null, null },
                    { new Guid("81391768-6642-46cb-bcaf-674bdc535c3d"), null, "Anakisten bluberry", 2, "Anakisten Brewing", null, 0, null },
                    { new Guid("92f8265d-afea-457e-a67e-b8d9a2fa392f"), null, "Trapist lakrids", 3, "Trapist Brews", null, null, 0 },
                    { new Guid("f6b4825e-a1fc-45e8-8fb8-c56064ee25a4"), null, "Grimberger double amber", 1, "Grimberger Brewery", 3, null, null }
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
