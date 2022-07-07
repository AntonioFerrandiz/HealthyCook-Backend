using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Recipes_RecipeID",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RecipeID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Restaurants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RecipeID",
                table: "Restaurants",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Recipes_RecipeID",
                table: "Restaurants",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
