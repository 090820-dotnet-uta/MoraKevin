using Microsoft.EntityFrameworkCore.Migrations;
using System.Numerics;

namespace P0.Migrations
{
    public partial class UpdateCardNumToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CardNumber",
                table: "BillingInformation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "BillingInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
