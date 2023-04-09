using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class iniite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698a47a6-be4c-4d92-bd4a-402ecbf2cdaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8273bcae-a32a-41b9-8ef0-3e5761040d69");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24d512a1-13a6-4304-80b3-11d990549352", "247cc98b-ceda-4472-a65e-9e0b6f8ebb4d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92d3623b-0efb-41a6-8200-de482a8627d0", "1221a0e7-ff13-4b46-955c-0e2ca4a241e9", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24d512a1-13a6-4304-80b3-11d990549352");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d3623b-0efb-41a6-8200-de482a8627d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8273bcae-a32a-41b9-8ef0-3e5761040d69", "37ec7e01-bf2c-488d-b6b3-eaf16a79c707", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "698a47a6-be4c-4d92-bd4a-402ecbf2cdaa", "451b279e-83e5-4168-8432-286fb83ac82c", "User", null });
        }
    }
}
