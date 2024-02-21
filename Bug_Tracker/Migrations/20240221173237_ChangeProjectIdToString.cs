using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bug_Tracker.Migrations
{
    public partial class ChangeProjectIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joins_Projects_ProjectId1",
                table: "Joins");

            migrationBuilder.DropIndex(
                name: "IX_Joins_ProjectId1",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Joins");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "HostProjectId",
                table: "AllBugs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_ProjectId",
                table: "Joins",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joins_Projects_ProjectId",
                table: "Joins",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joins_Projects_ProjectId",
                table: "Joins");

            migrationBuilder.DropIndex(
                name: "IX_Joins_ProjectId",
                table: "Joins");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Projects",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId1",
                table: "Joins",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HostProjectId",
                table: "AllBugs",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_ProjectId1",
                table: "Joins",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Joins_Projects_ProjectId1",
                table: "Joins",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
