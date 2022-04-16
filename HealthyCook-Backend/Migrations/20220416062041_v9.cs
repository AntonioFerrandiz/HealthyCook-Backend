﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserID",
                table: "Recipes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserID",
                table: "Recipes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Recipes");
        }
    }
}
