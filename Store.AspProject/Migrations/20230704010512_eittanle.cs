using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.AspProject.Migrations
{
    public partial class eittanle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Rememberme",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rememberme",
                table: "users");
        }
    }
}
