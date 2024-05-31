﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliasDb.Migrations
{
    /// <inheritdoc />
    public partial class LoginUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the new UserId column
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Logins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            // Fetch the first UserId from the AspNetUsers table and update the Logins table
            migrationBuilder.Sql(@"
                UPDATE Logins 
                SET UserId = (SELECT Id FROM AspNetUsers LIMIT 1)
                WHERE UserId = ''
            ");

            // Create the index on the UserId column
            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");

            // Add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AspNetUsers_UserId",
                table: "Logins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AspNetUsers_UserId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_UserId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Logins");
        }
    }
}
