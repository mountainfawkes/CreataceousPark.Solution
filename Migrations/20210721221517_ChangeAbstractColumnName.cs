using Microsoft.EntityFrameworkCore.Migrations;

namespace CreataceousPark.Solution.Migrations
{
    public partial class ChangeAbstractColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Abstract",
                table: "Headlines",
                newName: "Summary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Headlines",
                newName: "Abstract");
        }
    }
}
