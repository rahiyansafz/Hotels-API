using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.DataAccess.Migrations
{
    public partial class RemovedIsFavCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ccf5e50-cdc5-46aa-9298-45c10824f12a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7ca544-6fe1-4adb-b292-284937db75b9");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90512e5b-2e87-4657-bc26-52ab3e97b125", "497d701a-5dee-4eb5-80db-5258b9242c47", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff943e8b-2df1-4ec4-a466-e7e048fd4257", "17b1b808-038c-435f-9bc4-1907e4b4c00b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90512e5b-2e87-4657-bc26-52ab3e97b125");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff943e8b-2df1-4ec4-a466-e7e048fd4257");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ccf5e50-cdc5-46aa-9298-45c10824f12a", "76f02ce4-aa54-4551-9554-65c1227934a7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af7ca544-6fe1-4adb-b292-284937db75b9", "7b42aadc-3604-42c8-802c-b87eab22830f", "User", "USER" });
        }
    }
}
