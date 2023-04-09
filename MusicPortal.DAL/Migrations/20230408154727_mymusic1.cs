using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class mymusic1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "814a7195-f936-4b29-a1d4-14076faec4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e5a4b1-568d-4acb-a60a-77e10b6ae0b4");

            migrationBuilder.AddColumn<Guid>(
                name: "MyMusicId",
                table: "Musics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MyMusics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyMusics_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76d97104-4424-4e1f-98d3-992b7d6942b7", "1bcf6993-7272-43ea-a784-7193ffb68e65", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8ef6233-581d-48bc-b963-5d62f760aa74", "cea140d8-3790-4163-ba49-a9cd6c80169a", "User", null });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MyMusicId",
                table: "Musics",
                column: "MyMusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMusics_AuthorId",
                table: "MyMusics",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MyMusics_MyMusicId",
                table: "Musics",
                column: "MyMusicId",
                principalTable: "MyMusics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MyMusics_MyMusicId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "MyMusics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MyMusicId",
                table: "Musics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76d97104-4424-4e1f-98d3-992b7d6942b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ef6233-581d-48bc-b963-5d62f760aa74");

            migrationBuilder.DropColumn(
                name: "MyMusicId",
                table: "Musics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "814a7195-f936-4b29-a1d4-14076faec4fa", "1be02646-3abc-4e8e-8bab-d3d930f0b511", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1e5a4b1-568d-4acb-a60a-77e10b6ae0b4", "6a96101d-56a1-42e1-a748-8b21ea34cc84", "User", null });
        }
    }
}
