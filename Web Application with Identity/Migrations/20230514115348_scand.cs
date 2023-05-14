using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Application_with_Identity.Migrations
{
    public partial class scand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2023, 5, 14, 14, 53, 47, 793, DateTimeKind.Local).AddTicks(188), 0.0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 55, 52, 927, DateTimeKind.Local).AddTicks(8646), 50.0, 2 });
        }
    }
}
