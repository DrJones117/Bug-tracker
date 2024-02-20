using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bug_Tracker.Migrations
{
    public partial class AddBugDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bug_Projects_HostProjectId",
                table: "Bug");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bug",
                table: "Bug");

            migrationBuilder.RenameTable(
                name: "Bug",
                newName: "AllBugs");

            migrationBuilder.RenameIndex(
                name: "IX_Bug_HostProjectId",
                table: "AllBugs",
                newName: "IX_AllBugs_HostProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllBugs",
                table: "AllBugs",
                column: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllBugs_Projects_HostProjectId",
                table: "AllBugs",
                column: "HostProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllBugs_Projects_HostProjectId",
                table: "AllBugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllBugs",
                table: "AllBugs");

            migrationBuilder.RenameTable(
                name: "AllBugs",
                newName: "Bug");

            migrationBuilder.RenameIndex(
                name: "IX_AllBugs_HostProjectId",
                table: "Bug",
                newName: "IX_Bug_HostProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bug",
                table: "Bug",
                column: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bug_Projects_HostProjectId",
                table: "Bug",
                column: "HostProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
