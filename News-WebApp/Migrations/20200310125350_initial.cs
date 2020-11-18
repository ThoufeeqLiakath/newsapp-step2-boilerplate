using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News_WebApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.UserId, x.Password });
                });

            migrationBuilder.CreateTable(
                name: "NewsList",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UrlToImage = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsList", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_NewsList_Users_UserId1_UserPassword",
                        columns: x => new { x.UserId1, x.UserPassword },
                        principalTable: "Users",
                        principalColumns: new[] { "UserId", "Password" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password" },
                values: new object[] { "Jack", "password@123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password" },
                values: new object[] { "John", "password@123" });

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_UserId1_UserPassword",
                table: "NewsList",
                columns: new[] { "UserId1", "UserPassword" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
