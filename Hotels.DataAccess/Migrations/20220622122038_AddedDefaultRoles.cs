using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.DataAccess.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7b950fd-6fd7-4f89-bbb6-319ec7f98fa3", "807d3aea-0c9e-4978-9238-5efd2f0aa0f6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9daf626-bf5c-4954-a346-0578869ad597", "73b0fee7-b871-42be-a77a-32935bed064d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b950fd-6fd7-4f89-bbb6-319ec7f98fa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9daf626-bf5c-4954-a346-0578869ad597");
        }
    }
}
