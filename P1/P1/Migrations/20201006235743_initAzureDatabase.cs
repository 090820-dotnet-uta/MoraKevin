using Microsoft.EntityFrameworkCore.Migrations;

namespace P1.Migrations
{
    public partial class initAzureDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingInformation",
                columns: table => new
                {
                    BillingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOnCard = table.Column<string>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    ExpirationMonth = table.Column<int>(nullable: false),
                    ExpirationYear = table.Column<int>(nullable: false),
                    SecurityCode = table.Column<int>(nullable: false),
                    AddressNum = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: false),
                    AddressCity = table.Column<string>(nullable: false),
                    AddressState = table.Column<string>(nullable: false),
                    AddressZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInformation", x => x.BillingID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AddressNum = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    AddressZipCode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInformation",
                columns: table => new
                {
                    ShippingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNum = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: false),
                    AddressCity = table.Column<string>(nullable: false),
                    AddressState = table.Column<string>(nullable: false),
                    AddressZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInformation", x => x.ShippingID);
                });

            migrationBuilder.CreateTable(
                name: "CustomersBilling",
                columns: table => new
                {
                    CustomerBillingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    BillingID = table.Column<int>(nullable: false),
                    Main = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersBilling", x => x.CustomerBillingID);
                    table.ForeignKey(
                        name: "FK_CustomersBilling_BillingInformation_BillingID",
                        column: x => x.BillingID,
                        principalTable: "BillingInformation",
                        principalColumn: "BillingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersBilling_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Username);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultLocations",
                columns: table => new
                {
                    DefaultLocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultLocations", x => x.DefaultLocationID);
                    table.ForeignKey(
                        name: "FK_DefaultLocations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultLocations_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationProducts",
                columns: table => new
                {
                    LocationProductsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Inventory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationProducts", x => x.LocationProductsID);
                    table.ForeignKey(
                        name: "FK_LocationProducts_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersShipping",
                columns: table => new
                {
                    CustomerShippingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ShippingID = table.Column<int>(nullable: false),
                    Main = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersShipping", x => x.CustomerShippingID);
                    table.ForeignKey(
                        name: "FK_CustomersShipping_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersShipping_ShippingInformation_ShippingID",
                        column: x => x.ShippingID,
                        principalTable: "ShippingInformation",
                        principalColumn: "ShippingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    OrderTime = table.Column<string>(nullable: true),
                    BillingID = table.Column<int>(nullable: false),
                    ShippingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_BillingInformation_BillingID",
                        column: x => x.BillingID,
                        principalTable: "BillingInformation",
                        principalColumn: "BillingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingInformation_ShippingID",
                        column: x => x.ShippingID,
                        principalTable: "ShippingInformation",
                        principalColumn: "ShippingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductsID);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_CustomersBilling_BillingID",
                table: "CustomersBilling",
                column: "BillingID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBilling_CustomerID",
                table: "CustomersBilling",
                column: "CustomerID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersShipping_CustomerID",
                table: "CustomersShipping",
                column: "CustomerID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersShipping_ShippingID",
                table: "CustomersShipping",
                column: "ShippingID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultLocations_CustomerID",
                table: "DefaultLocations",
                column: "CustomerID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultLocations_LocationID",
                table: "DefaultLocations",
                column: "LocationID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_LocationProducts_LocationID",
                table: "LocationProducts",
                column: "LocationID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_LocationProducts_ProductID",
                table: "LocationProducts",
                column: "ProductID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderID",
                table: "OrderProducts",
                column: "OrderID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductID",
                table: "OrderProducts",
                column: "ProductID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingID",
                table: "Orders",
                column: "BillingID", 
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationID",
                table: "Orders",
                column: "LocationID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingID",
                table: "Orders",
                column: "ShippingID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_CustomerID",
                table: "UserAccounts",
                column: "CustomerID",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersBilling");

            migrationBuilder.DropTable(
                name: "CustomersShipping");

            migrationBuilder.DropTable(
                name: "DefaultLocations");

            migrationBuilder.DropTable(
                name: "LocationProducts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BillingInformation");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ShippingInformation");
        }
    }
}
