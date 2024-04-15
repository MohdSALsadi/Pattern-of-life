using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pattern_of_life.Migrations
{
    public partial class DMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatitudeDMS",
                table: "ShipActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongitudeDMS",
                table: "ShipActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatitudeDMS",
                table: "ShipActivity");

            migrationBuilder.DropColumn(
                name: "LongitudeDMS",
                table: "ShipActivity");
        }
    }
}
