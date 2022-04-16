using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipesID",
                table: "Recipes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
