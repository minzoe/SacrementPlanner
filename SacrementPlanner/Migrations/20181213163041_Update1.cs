using Microsoft.EntityFrameworkCore.Migrations;

namespace SacrementPlanner.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bishopric",
                table: "Planner",
                newName: "BishopricId");

            migrationBuilder.CreateIndex(
                name: "IX_Planner_BishopricId",
                table: "Planner",
                column: "BishopricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planner_Bishoprics_BishopricId",
                table: "Planner",
                column: "BishopricId",
                principalTable: "Bishoprics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planner_Bishoprics_BishopricId",
                table: "Planner");

            migrationBuilder.DropIndex(
                name: "IX_Planner_BishopricId",
                table: "Planner");

            migrationBuilder.RenameColumn(
                name: "BishopricId",
                table: "Planner",
                newName: "Bishopric");
        }
    }
}
