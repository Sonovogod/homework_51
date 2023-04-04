using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.Migrations
{
    public partial class addeddicriptiontoPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Phone",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Phone");
        }
    }
}
