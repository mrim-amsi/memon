using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Application_with_Identity.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 55, 52, 927, DateTimeKind.Local).AddTicks(8646), 50.0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 11, 5, 57, 26, DateTimeKind.Local).AddTicks(1453));
        }
    }
}
