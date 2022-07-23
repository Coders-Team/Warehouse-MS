using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse_MS.Migrations
{
    public partial class ChangedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 430.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2010, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "ExpiredDate", "Weight" },
                values: new object[] { new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 });
        }
    }
}
