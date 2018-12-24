using Microsoft.EntityFrameworkCore.Migrations;

namespace Remind.Migrations
{
    public partial class AddFrequencyReminderIdToRemindersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReminderFrequencyId",
                table: "Reminders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ReminderFrequencyId",
                table: "Reminders",
                column: "ReminderFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_ReminderFrequency_ReminderFrequencyId",
                table: "Reminders",
                column: "ReminderFrequencyId",
                principalTable: "ReminderFrequency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_ReminderFrequency_ReminderFrequencyId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_ReminderFrequencyId",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "ReminderFrequencyId",
                table: "Reminders");
        }
    }
}
