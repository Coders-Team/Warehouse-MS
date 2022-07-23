using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse_MS.Migrations
{
    public partial class updateTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "newLocation",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newLocation",
                table: "Transaction");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
