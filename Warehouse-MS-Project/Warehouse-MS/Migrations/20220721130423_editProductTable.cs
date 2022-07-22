using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse_MS.Migrations
{
    public partial class editProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
