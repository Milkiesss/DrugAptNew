using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugNetwork = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Address_Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address_House = table.Column<int>(type: "integer", nullable: false),
                    Address_PostalCode = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExteranlId = table.Column<string>(type: "text", nullable: false),
                    Email_Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryCodeId = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugId = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugStoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Amount = table.Column<double>(type: "double precision", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugItems_DrugStores_DrugStoreId",
                        column: x => x.DrugStoreId,
                        principalTable: "DrugStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugItems_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugId = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugStoreId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteDrugs_DrugStores_DrugStoreId",
                        column: x => x.DrugStoreId,
                        principalTable: "DrugStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteDrugs_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteDrugs_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugItems_DrugId",
                table: "DrugItems",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItems_DrugStoreId",
                table: "DrugItems",
                column: "DrugStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_CountryId",
                table: "Drugs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDrugs_DrugId",
                table: "FavoriteDrugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDrugs_DrugStoreId",
                table: "FavoriteDrugs",
                column: "DrugStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDrugs_ProfileId",
                table: "FavoriteDrugs",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugItems");

            migrationBuilder.DropTable(
                name: "FavoriteDrugs");

            migrationBuilder.DropTable(
                name: "DrugStores");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
