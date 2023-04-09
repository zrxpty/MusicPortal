using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class mymusic11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76d97104-4424-4e1f-98d3-992b7d6942b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ef6233-581d-48bc-b963-5d62f760aa74");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8273bcae-a32a-41b9-8ef0-3e5761040d69", "37ec7e01-bf2c-488d-b6b3-eaf16a79c707", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "698a47a6-be4c-4d92-bd4a-402ecbf2cdaa", "451b279e-83e5-4168-8432-286fb83ac82c", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "76d97104-4424-4e1f-98d3-992b7d6942b7", "1bcf6993-7272-43ea-a784-7193ffb68e65", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8ef6233-581d-48bc-b963-5d62f760aa74", "cea140d8-3790-4163-ba49-a9cd6c80169a", "User", null });
        }
    }
}
