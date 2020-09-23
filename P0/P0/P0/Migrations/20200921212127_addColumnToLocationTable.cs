using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class addColumnToLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Locations");
        }
    }
}
