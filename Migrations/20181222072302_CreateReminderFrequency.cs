using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Remind.Migrations
{
    public partial class CreateReminderFrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultReminderFrequency",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ReminderFrequencyId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReminderFrequency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NumberOfDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderFrequency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReminderFrequencyId",
                table: "Users",
                column: "ReminderFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ReminderFrequency_ReminderFrequencyId",
                table: "Users",
                column: "ReminderFrequencyId",
                principalTable: "ReminderFrequency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ReminderFrequency_ReminderFrequencyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ReminderFrequency");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReminderFrequencyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReminderFrequencyId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "DefaultReminderFrequency",
                table: "Users",
                nullable: true);
        }
    }
}
