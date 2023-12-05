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
                    { new Guid("39377e08-cea2-4c12-84f4-619db5de4971"), "IPA Beer Enthusiasts" },
                    { new Guid("3d25023b-a15a-4efe-8125-000c55af99e9"), "Craft Beer Enthusiasts" },
                    { new Guid("8b462ca4-15ee-4cfe-bb85-86324e572aa6"), "Ale Beer Enthusiasts" },
                    { new Guid("b63aa8ca-2e54-44e8-8750-cfd4de6b95fb"), "Stout Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName" },
                values: new object[,]
                {
                    { new Guid("19021e3f-42fe-4b83-b20a-38c704f2674c"), "john@example.com", "John Doe" },
                    { new Guid("1de9a470-c144-4424-8c19-4091c5233855"), "Peter@example.com", "Peter Doe" },
                    { new Guid("1f44fec8-33fe-4e10-814a-9a6299cec163"), "Lope@example.com", "Lope Doe" },
                    { new Guid("4b03a19c-b47d-48fb-9269-60829d75f59f"), "Pop@example.com", "Pop Doe" },
                    { new Guid("c70def6d-5ae1-482a-8b9a-ab8816cd547e"), "Jason@example.com", "Jason Doe" },
                    { new Guid("d251288e-3c3e-4b9d-9056-57db02f1bce0"), "Joson@example.com", "Joson Doe" },
                    { new Guid("d5fa6e8a-35e6-4db8-a6ff-5db22cb58f11"), "Gope@example.com", "Gope Doe" },
                    { new Guid("d6f14cf7-cdd8-4c52-961e-933aa3e219dc"), "Casper@example.com", "Casper Doe" },
                    { new Guid("db41cd04-5b34-492e-9537-7ac5e4d02c3a"), "Dask@example.com", "Dask Doe" }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerName", "BeerType", "Brewery", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("5d44686e-a27d-4b87-a670-a76823fe1105"), 1, "IPA london", 0, "London Brewing Co", null, null, null },
                    { new Guid("6ee23fe6-e841-48d4-bd62-353f9caefd9c"), null, "Carlsberg pilsner", 1, "Carlsberg Brewery", 0, null, null },
                    { new Guid("b3b8f151-77be-4911-b8dd-0c9a4bf622a1"), null, "Trapist lakrids", 3, "Trapist Brews", null, null, 0 },
                    { new Guid("c9811370-75df-4c56-9c26-c18bf8e11db4"), null, "Grimberger double amber", 1, "Grimberger Brewery", 3, null, null },
                    { new Guid("e4c25d0d-4d03-4815-82b7-5b85873c7432"), 0, "Geuss new", 0, "Geuss Brewery", null, null, null },
                    { new Guid("f689afb8-4862-4aa9-8ed9-0c8f263b97bd"), null, "Anakisten bluberry", 2, "Anakisten Brewing", null, 0, null }
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
