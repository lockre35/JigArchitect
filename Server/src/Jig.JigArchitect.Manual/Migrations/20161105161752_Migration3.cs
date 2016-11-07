using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jig.JigArchitect.Manual.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Schemas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_ApplicationId",
                table: "Schemas",
                column: "ApplicationId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schemas_Applications_ApplicationId",
                table: "Schemas",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schemas_Applications_ApplicationId",
                table: "Schemas");

            migrationBuilder.DropIndex(
                name: "IX_Schemas_ApplicationId",
                table: "Schemas");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Schemas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Applications");
        }
    }
}
