using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_ChallengeType_ChallengeTypeId",
                table: "Challenge");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar_url",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeTypeId",
                table: "Challenge",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_ChallengeType_ChallengeTypeId",
                table: "Challenge",
                column: "ChallengeTypeId",
                principalTable: "ChallengeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_ChallengeType_ChallengeTypeId",
                table: "Challenge");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_RoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "avatar_url",
                table: "User");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeTypeId",
                table: "Challenge",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_ChallengeType_ChallengeTypeId",
                table: "Challenge",
                column: "ChallengeTypeId",
                principalTable: "ChallengeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
