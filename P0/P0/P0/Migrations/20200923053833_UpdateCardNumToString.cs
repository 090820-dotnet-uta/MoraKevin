using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class UpdateCardNumToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "BillingInformation",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CardNumber",
                table: "BillingInformation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
