using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class AddBillingShippingToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingID",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingID",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingID",
                table: "Orders",
                column: "BillingID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingID",
                table: "Orders",
                column: "ShippingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BillingInformation_BillingID",
                table: "Orders",
                column: "BillingID",
                principalTable: "BillingInformation",
                principalColumn: "BillingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingInformation_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "ShippingInformation",
                principalColumn: "ShippingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BillingInformation_BillingID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingInformation_ShippingID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingID",
                table: "Orders");
        }
    }
}
