using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_RecipeDetails_RecipeDetailsID",
                table: "RecipeSteps");

            migrationBuilder.DropIndex(
                name: "IX_RecipeSteps_RecipeDetailsID",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "RecipeDetailsID",
                table: "RecipeSteps");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "RecipeSteps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeID",
                table: "RecipeSteps",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeID",
                table: "RecipeSteps",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeID",
                table: "RecipeSteps");

            migrationBuilder.DropIndex(
                name: "IX_RecipeSteps_RecipeID",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "RecipeSteps");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailsID",
                table: "RecipeSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeDetailsID",
                table: "RecipeSteps",
                column: "RecipeDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_RecipeDetails_RecipeDetailsID",
                table: "RecipeSteps",
                column: "RecipeDetailsID",
                principalTable: "RecipeDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
