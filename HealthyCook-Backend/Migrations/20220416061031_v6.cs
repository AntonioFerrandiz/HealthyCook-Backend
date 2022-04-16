using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipes_RecipesID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipesID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipesID",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailsID",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeDetailsID",
                table: "Recipes",
                column: "RecipeDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeDetails_RecipeDetailsID",
                table: "Recipes",
                column: "RecipeDetailsID",
                principalTable: "RecipeDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeDetails_RecipeDetailsID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeDetailsID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeDetailsID",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipesID",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipesID",
                table: "Recipes",
                column: "RecipesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipes_RecipesID",
                table: "Recipes",
                column: "RecipesID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
