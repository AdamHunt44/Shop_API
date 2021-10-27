using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderNumber" },
                values: new object[] { 1, new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "1234" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Kitchen", "Tall blue coffee mug", "Coffee mug", 3.99m, 10 },
                    { 2, "Tools", "A heavy duty aluminium step ladder", "Step Ladder", 27.99m, 10 },
                    { 3, "Kitchen", "A proper brew", "Kettle", 13.99m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[] { 1, 1, 1, 5, 3.99m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[] { 2, 1, 3, 5, 13.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);
        }
    }
}
