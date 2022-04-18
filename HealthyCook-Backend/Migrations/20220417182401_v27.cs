using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTim",
                table: "RecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "PreparationTime",
                table: "RecipeDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "RecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "PreparationTim",
                table: "RecipeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
