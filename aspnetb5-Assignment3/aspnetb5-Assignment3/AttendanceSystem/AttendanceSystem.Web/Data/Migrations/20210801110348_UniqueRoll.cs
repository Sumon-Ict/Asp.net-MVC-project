using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceSystem.Web.Data.Migrations
{
    public partial class UniqueRoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentRollNumber",
                table: "Students",
                column: "StudentRollNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentRollNumber",
                table: "Students");
        }
    }
}
