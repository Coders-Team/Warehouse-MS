using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse_MS.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "....", "food" },
                    { 2, "....", "metals" },
                    { 3, "....", "Cleaning materials" },
                    { 4, "....", "raw material" }
                });

            migrationBuilder.InsertData(
                table: "StorageType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "....", "low temperature" },
                    { 2, "....", "on shelves" },
                    { 3, "....", "on the floor" },
                    { 4, "....", "recycle area" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Description", "Location", "Name", "SizeInUnit", "UserId" },
                values: new object[,]
                {
                    { 1, " ....", "Amman", "Warehouse1", 100, null },
                    { 2, " ....", "aqaba", "Warehouse2", 50, null },
                    { 3, " ....", "Irbid", "Warehouse3", 150, null },
                    { 4, " ....", "zarqa", "Warehouse4", 200, null }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "Description", "LocationInWarehouse", "Name", "SizeInUnit", "StorageTypeId", "WarehouseId" },
                values: new object[,]
                {
                    { 1, " ....", "floor 1 west", "Storage1", 15, 1, 1 },
                    { 2, " ....", "floor 2 east", "Storage2", 30, 2, 1 },
                    { 3, " ....", "floor 1 behind the fridge ", "Storage3", 55, 3, 1 },
                    { 4, " ....", "floor 1 production section", "Storage4", 25, 3, 2 },
                    { 5, " ....", "floor 2 between section a and section t", "Storage5", 25, 4, 2 },
                    { 6, " ....", "floor 1 south", "Storage6", 50, 3, 3 },
                    { 7, " ....", "floor 1 west", "Storage7", 50, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BarcodeNum", "Date", "Description", "ExpiredDate", "Name", "Photo", "ProductTypeId", "SizeInUnit", "StorageId", "StorageTypeId", "Weight" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product1", null, 1, 5, 1, 1, 100.0 },
                    { 2, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product2", null, 4, 3, 1, 1, 100.0 },
                    { 3, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product3", null, 1, 5, 1, 1, 100.0 },
                    { 4, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product4", null, 2, 1, 2, 2, 100.0 },
                    { 5, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product5", null, 1, 10, 2, 2, 100.0 },
                    { 6, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product6", null, 3, 2, 3, 3, 100.0 },
                    { 7, null, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " ....", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product7", null, 4, 15, 5, 4, 100.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StorageType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StorageType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StorageType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StorageType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
