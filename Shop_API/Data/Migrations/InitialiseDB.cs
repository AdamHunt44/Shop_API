using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Data.Migrations
{
    public class InitialisaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false, defaultValue: ""),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

        migrationBuilder.CreateTable(
               name: "Orders",
               columns: table => new
               {
                   OrderId = table.Column<int>(nullable: false)
                                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   OrderDate = table.Column<DateTime>(nullable: false),
                   OrderNumber = table.Column<string>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Orders", x => x.Id);

               });


            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                   Id = table.Column<int>(nullable: false)
                                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   ProductId = table.Column<int>(nullable: true),
                   Quantity = table.Column<int>(nullable: false),
                   UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                   OrderId = table.Column<int>(nullable: true),
                },
               constraints: table =>
               {
                   table.PrimaryKey("PK_OrderItem", x => x.Id);
                   table.ForeignKey(
                       name: "FK_OrderItem_Orders_OrderId",
                       column: x => x.OrderId,
                       princpleTable: "Orders",
                       principleColumn: "Id",
                       onDelete: ReferenceAction.Restrict);
                   table.ForeignKey(
                       name: "FK_OrderItem_Products_ProductId",
                       column: x => x.ProductId,
                       princpleTable: "Products",
                       principleColumn: "Id",
                       onDelete: ReferenceAction.Restrict);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
