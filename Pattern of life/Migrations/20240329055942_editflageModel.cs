using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pattern_of_life.Migrations
{
    public partial class editflageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlagImage",
                table: "FlagStates",
                newName: "FlagImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlagImagePath",
                table: "FlagStates",
                newName: "FlagImage");
        }
    }
}
