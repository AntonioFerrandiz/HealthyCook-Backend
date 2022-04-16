using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "RecipeDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_RecipeID",
                table: "RecipeDetails",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_Recipes_RecipeID",
                table: "RecipeDetails",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_Recipes_RecipeID",
                table: "RecipeDetails");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDetails_RecipeID",
                table: "RecipeDetails");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "RecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailsID",
                table: "Recipes",
                type: "int",
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
    }
}
