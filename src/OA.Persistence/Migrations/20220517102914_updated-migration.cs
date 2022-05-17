using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.Persistence.Migrations
{
    public partial class updatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSalary",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserSalary",
                table: "Users");
        }
    }
}
