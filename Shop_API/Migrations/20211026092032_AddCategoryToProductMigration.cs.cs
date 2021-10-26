using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_API.Migrations
{
    public partial class AddCategoryToProductMigrationcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 5, "TEST", "A new test product for our users", "TEST2", 3.5, 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 3, "A new test product for our users", "TEST", 3.5, 50 });
        }
    }
}
