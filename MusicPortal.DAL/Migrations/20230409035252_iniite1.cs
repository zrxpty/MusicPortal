using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class iniite1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MyMusics_MyMusicId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MyMusicId",
                table: "Musics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24d512a1-13a6-4304-80b3-11d990549352");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d3623b-0efb-41a6-8200-de482a8627d0");

            migrationBuilder.DropColumn(
                name: "MyMusicId",
                table: "Musics");

            migrationBuilder.AddColumn<Guid>(
                name: "MusicsId",
                table: "MyMusics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d193cf43-529b-48b7-8a7b-fd3e856cbb5b", "5cbbbbf7-f7e8-41bd-a5d0-1b20fe9741c0", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c503951-9b2d-47ca-8b87-a3036bcb304b", "47340007-64d3-43b2-aec5-1d4d25281cb7", "User", null });

            migrationBuilder.CreateIndex(
                name: "IX_MyMusics_MusicsId",
                table: "MyMusics",
                column: "MusicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyMusics_Musics_MusicsId",
                table: "MyMusics",
                column: "MusicsId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyMusics_Musics_MusicsId",
                table: "MyMusics");

            migrationBuilder.DropIndex(
                name: "IX_MyMusics_MusicsId",
                table: "MyMusics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c503951-9b2d-47ca-8b87-a3036bcb304b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d193cf43-529b-48b7-8a7b-fd3e856cbb5b");

            migrationBuilder.DropColumn(
                name: "MusicsId",
                table: "MyMusics");

            migrationBuilder.AddColumn<Guid>(
                name: "MyMusicId",
                table: "Musics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24d512a1-13a6-4304-80b3-11d990549352", "247cc98b-ceda-4472-a65e-9e0b6f8ebb4d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92d3623b-0efb-41a6-8200-de482a8627d0", "1221a0e7-ff13-4b46-955c-0e2ca4a241e9", "User", null });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MyMusicId",
                table: "Musics",
                column: "MyMusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MyMusics_MyMusicId",
                table: "Musics",
                column: "MyMusicId",
                principalTable: "MyMusics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
