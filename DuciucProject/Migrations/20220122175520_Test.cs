using Microsoft.EntityFrameworkCore.Migrations;

namespace DuciucProject.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Milestones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_UserId",
                table: "Milestones",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestones_Users_UserId",
                table: "Milestones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Milestones_Users_UserId",
                table: "Milestones");

            migrationBuilder.DropIndex(
                name: "IX_Milestones_UserId",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Milestones");
        }
    }
}
