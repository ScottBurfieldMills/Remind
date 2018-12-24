using Microsoft.EntityFrameworkCore.Migrations;

namespace Remind.Migrations
{
    public partial class AddGenericFieldForStoringNotificationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "UserNotificationTypes",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserNotificationTypes");
        }
    }
}
