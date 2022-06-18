using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
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
                    Rating = table.Column<double>(type: "float", nullable: false),
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
                columns: new[] { "Id", "Address", "CityId", "Description", "Name", "Rating" },
                values: new object[] { 1, "79/A Commercial Area Airport Rd, Dhaka-1229", 1, "Luxe, modern lodging offering elegant rooms & suites, plus an infinity pool & chic dining.", "Le Méridien", 4.5999999999999996 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "Name", "Rating" },
                values: new object[] { 2, "Shahid Saifuddin Khaled Rd, Chattogram-4000", 2, "Polished quarters in a contemporary hotel offering an infinity pool, a spa & 3 restaurants.", "Radisson Blu Chattogram Bay View", 4.5999999999999996 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "Name", "Rating" },
                values: new object[] { 3, "931 Laksham Rd, Cumilla-3501", 3, "Laid-back hotel featuring a restaurant & a fitness room, as well as breakfast & parking.", "OASIS Hotel", 4.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
