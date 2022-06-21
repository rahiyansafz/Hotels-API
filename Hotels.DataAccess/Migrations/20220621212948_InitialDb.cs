using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.DataAccess.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    MinPrice = table.Column<double>(type: "float", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    Occupancies = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayPriceRaw = table.Column<double>(type: "float", nullable: false),
                    MaxOccupancies = table.Column<int>(type: "int", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    ServiceCharge = table.Column<double>(type: "float", nullable: false),
                    DiscountedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Division", "Name" },
                values: new object[] { 1, "Bangladesh", "Dhaka", "Dhaka" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Division", "Name" },
                values: new object[] { 2, "Bangladesh", "Chittagong", "Chittagong" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Division", "Name" },
                values: new object[] { 3, "Bangladesh", "Comilla", "Comilla" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 1, "79/A Commercial Area Airport Rd, Dhaka-1229", 1, "Luxe, modern lodging offering elegant rooms & suites, plus an infinity pool & chic dining.", 25000.0, 4000.0, "Le Méridien", 3, 4.5999999999999996, 44 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 2, "Shahid Saifuddin Khaled Rd, Chattogram-4000", 2, "Polished quarters in a contemporary hotel offering an infinity pool, a spa & 3 restaurants.", 25000.0, 4000.0, "Radisson Blu Chattogram Bay View", 3, 4.5999999999999996, 44 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 3, "931 Laksham Rd, Cumilla-3501", 3, "Laid-back hotel featuring a restaurant & a fitness room, as well as breakfast & parking.", 25000.0, 4000.0, "OASIS Hotel", 3, 4.0, 44 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BathroomCount", "BedCount", "CheckIn", "CheckOut", "DiscountedPrice", "DisplayPrice", "DisplayPriceRaw", "HotelId", "IsAvailable", "IsBooked", "IsFavourite", "MaxOccupancies", "Name", "ServiceCharge", "Type" },
                values: new object[] { 1, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 1, true, false, false, 6, "Studio Apartment", 15.0, 8 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BathroomCount", "BedCount", "CheckIn", "CheckOut", "DiscountedPrice", "DisplayPrice", "DisplayPriceRaw", "HotelId", "IsAvailable", "IsBooked", "IsFavourite", "MaxOccupancies", "Name", "ServiceCharge", "Type" },
                values: new object[] { 2, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 2, true, false, false, 6, "Double Deluxe", 15.0, 4 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BathroomCount", "BedCount", "CheckIn", "CheckOut", "DiscountedPrice", "DisplayPrice", "DisplayPriceRaw", "HotelId", "IsAvailable", "IsBooked", "IsFavourite", "MaxOccupancies", "Name", "ServiceCharge", "Type" },
                values: new object[] { 3, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 3, true, false, false, 6, "Twin Deluxe", 15.0, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
