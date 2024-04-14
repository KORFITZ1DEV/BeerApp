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
                    { new Guid("43393fb3-c80a-47e0-a3be-dda7632073b4"), "New Beer Enthusiasts" },
                    { new Guid("71e9a6a6-877a-44c5-a6df-681241dbab19"), "Ale Beer Enthusiasts" },
                    { new Guid("75b04c6c-22e0-41de-93ee-dd02b374237e"), "IPA Beer Enthusiasts" },
                    { new Guid("e11d2561-fb66-4a18-93be-ec122b0fd9d4"), "Stout Beer Enthusiasts" },
                    { new Guid("efc393c7-063a-4595-bfa0-a819f1adcc09"), "Test Beer Enthusiasts" },
                    { new Guid("fa655159-07e9-42a0-9655-5fef0ec31283"), "Craft Beer Enthusiasts" }
                });

            migrationBuilder.InsertData(
                table: "BEERLOVERS",
                columns: new[] { "BeerLoverID", "BeerLoverEmail", "BeerLoverName" },
                values: new object[,]
                {
                    { new Guid("321e4734-7b8b-4d95-8aa6-a960a941bbdb"), "Pop@example.com", "Pop Doe" },
                    { new Guid("359a75b7-497c-4476-a2a2-7aa2d04d8bdc"), "Peter@example.com", "Peter Doe" },
                    { new Guid("6078963c-ef07-4ef8-9031-0ce84011c595"), "Gope@example.com", "Gope Doe" },
                    { new Guid("67b79d6e-1aa0-4829-bc20-5c3dd16e6316"), "Lope@example.com", "Lope Doe" },
                    { new Guid("8b454255-f001-4d6a-951b-2856b1a58a57"), "Dask@example.com", "Dask Doe" },
                    { new Guid("b35752b1-ecb1-491b-8a37-ff1c4b7a9e9e"), "john@example.com", "John Doe" },
                    { new Guid("d187fb0b-0061-4722-8949-a2b4851a68f8"), "Jason@example.com", "Jason Doe" },
                    { new Guid("d7468fb6-3f09-4319-86c8-da727647456f"), "Casper@example.com", "Casper Doe" },
                    { new Guid("ec5cff0e-5df6-429d-a177-4b9528a528d1"), "Joson@example.com", "Joson Doe" }
                });

            migrationBuilder.InsertData(
                table: "BEERS",
                columns: new[] { "BeerID", "AleSubType", "BeerName", "BeerType", "Brewery", "LagerSubType", "SpecialtyHybridSubType", "StrongAleSubType" },
                values: new object[,]
                {
                    { new Guid("0f356aa0-33d2-4f49-aa78-e7551c9f5da8"), null, "Grimberger double amber", 1, "Grimberger Brewery", 3, null, null },
                    { new Guid("351f4265-206f-418b-9729-0eb96daacec7"), null, "Carlsberg pilsner", 1, "Carlsberg Brewery", 0, null, null },
                    { new Guid("374b135e-e8c4-429c-ba89-909e82d22056"), 0, "Geuss new", 0, "Geuss Brewery", null, null, null },
                    { new Guid("5a6dbf58-e063-41d1-8865-572a5f88c300"), null, "Trapist lakrids", 3, "Trapist Brews", null, null, 0 },
                    { new Guid("69d377c9-24dc-4189-ad24-d9f9461e3fd5"), null, "Anakisten bluberry", 2, "Anakisten Brewing", null, 0, null },
                    { new Guid("7572a355-7aa7-43db-875a-79781ad1a537"), 1, "IPA london", 0, "London Brewing Co", null, null, null }
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
