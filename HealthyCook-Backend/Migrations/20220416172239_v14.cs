using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "RecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "RecipeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
