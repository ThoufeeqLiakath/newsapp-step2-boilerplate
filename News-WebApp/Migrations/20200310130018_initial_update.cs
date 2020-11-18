using Microsoft.EntityFrameworkCore.Migrations;

namespace News_WebApp.Migrations
{
    public partial class initial_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_Users_UserId1_UserPassword",
                table: "NewsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_NewsList_UserId1_UserPassword",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "NewsList");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NewsList",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_UserId",
                table: "NewsList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_Users_UserId",
                table: "NewsList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_Users_UserId",
                table: "NewsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_NewsList_UserId",
                table: "NewsList");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NewsList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "NewsList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "NewsList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                columns: new[] { "UserId", "Password" });

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_UserId1_UserPassword",
                table: "NewsList",
                columns: new[] { "UserId1", "UserPassword" });

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_Users_UserId1_UserPassword",
                table: "NewsList",
                columns: new[] { "UserId1", "UserPassword" },
                principalTable: "Users",
                principalColumns: new[] { "UserId", "Password" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
