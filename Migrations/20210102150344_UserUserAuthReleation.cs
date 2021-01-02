using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class UserUserAuthReleation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AuthId",
                table: "User",
                column: "AuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Auths_AuthId",
                table: "User",
                column: "AuthId",
                principalTable: "Auths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Auths_AuthId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AuthId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "User");
        }
    }
}
