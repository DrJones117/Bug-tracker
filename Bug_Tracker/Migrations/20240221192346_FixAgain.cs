using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bug_Tracker.Migrations
{
    public partial class FixAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllBugs_Projects_HostProjectId",
                table: "AllBugs");

            migrationBuilder.RenameColumn(
                name: "HostProjectId",
                table: "AllBugs",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AllBugs_HostProjectId",
                table: "AllBugs",
                newName: "IX_AllBugs_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllBugs_Projects_ProjectId",
                table: "AllBugs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllBugs_Projects_ProjectId",
                table: "AllBugs");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "AllBugs",
                newName: "HostProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AllBugs_ProjectId",
                table: "AllBugs",
                newName: "IX_AllBugs_HostProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllBugs_Projects_HostProjectId",
                table: "AllBugs",
                column: "HostProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
