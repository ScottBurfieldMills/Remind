using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Remind.Migrations
{
    public partial class AddNotificationTypesAndLinkToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserNotificationTypeId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemindAt",
                table: "Reminders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotificationTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotificationTypes_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserNotificationTypeId",
                table: "Users",
                column: "UserNotificationTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationTypes_NotificationTypeId",
                table: "UserNotificationTypes",
                column: "NotificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserNotificationTypes_UserNotificationTypeId",
                table: "Users",
                column: "UserNotificationTypeId",
                principalTable: "UserNotificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserNotificationTypes_UserNotificationTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserNotificationTypes");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserNotificationTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserNotificationTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RemindAt",
                table: "Reminders");
        }
    }
}
