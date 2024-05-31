﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliasDb.Migrations
{
    /// <inheritdoc />
    public partial class BasicEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    NickName = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddressStreet = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    AddressCity = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    AddressState = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    AddressZipCode = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    AddressCountry = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    Hobbies = table.Column<string>(type: "TEXT", nullable: true),
                    EmailPrefix = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneMobile = table.Column<string>(type: "TEXT", nullable: true),
                    BankAccountIBAN = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DefaultPasswordId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdentityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logins_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LoginId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passwords_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_DefaultPasswordId",
                table: "Identities",
                column: "DefaultPasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_IdentityId",
                table: "Logins",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_ServiceId",
                table: "Logins",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_LoginId",
                table: "Passwords",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Passwords_DefaultPasswordId",
                table: "Identities",
                column: "DefaultPasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Passwords_DefaultPasswordId",
                table: "Identities");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Identities");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
