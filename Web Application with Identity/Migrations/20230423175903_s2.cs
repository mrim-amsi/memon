using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Application_with_Identity.Migrations
{
    public partial class s2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Categories");
        }
    }
}
