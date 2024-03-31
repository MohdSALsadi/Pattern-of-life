using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pattern_of_life.Migrations
{
    public partial class flagEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlagImage",
                table: "FlagStates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagImage",
                table: "FlagStates");
        }
    }
}
