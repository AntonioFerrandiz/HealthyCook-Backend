using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Restaurants",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
