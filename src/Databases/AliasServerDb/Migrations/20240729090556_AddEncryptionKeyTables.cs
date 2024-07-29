﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliasServerDb.Migrations
{
    /// <inheritdoc />
    public partial class AddEncryptionKeyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delete all records from the Email table as adding PKI will break the existing data.
            migrationBuilder.Sql("DELETE FROM Emails");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEncryptionKeyId",
                table: "Emails",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PublicKey",
                table: "AliasVaultUsers",
                type: "TEXT",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserEmailClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    AddressLocal = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    AddressDomain = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmailClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmailClaims_AliasVaultUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AliasVaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEncryptionKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PublicKey = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEncryptionKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEncryptionKeys_AliasVaultUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AliasVaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UserEncryptionKeyId",
                table: "Emails",
                column: "UserEncryptionKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmailClaims_UserId",
                table: "UserEmailClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEncryptionKeys_UserId",
                table: "UserEncryptionKeys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_UserEncryptionKeys_UserEncryptionKeyId",
                table: "Emails",
                column: "UserEncryptionKeyId",
                principalTable: "UserEncryptionKeys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_UserEncryptionKeys_UserEncryptionKeyId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "UserEmailClaims");

            migrationBuilder.DropTable(
                name: "UserEncryptionKeys");

            migrationBuilder.DropIndex(
                name: "IX_Emails_UserEncryptionKeyId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "UserEncryptionKeyId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "PublicKey",
                table: "AliasVaultUsers");
        }
    }
}
