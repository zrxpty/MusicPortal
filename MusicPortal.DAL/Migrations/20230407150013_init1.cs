using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa3b98e-326d-44cf-bc64-e32d81f9b62f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8d63dfd-dcd1-4656-a5a0-96701f1581ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c37917bd-c959-49c2-bc32-12eece98bb6b", "b98a3b6f-1436-424f-9b9c-b831a24c9f6f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5be0c77c-ac5c-45b6-84ea-b5c00a7bca03", "bdad6af0-f9bd-455f-9f80-e90c116f2853", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be0c77c-ac5c-45b6-84ea-b5c00a7bca03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37917bd-c959-49c2-bc32-12eece98bb6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8d63dfd-dcd1-4656-a5a0-96701f1581ba", "2b424d73-0570-478f-b816-ce579e08ea5e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fa3b98e-326d-44cf-bc64-e32d81f9b62f", "fae4031c-e3a0-4dae-8f19-e790e5c95ebd", "User", null });
        }
    }
}
