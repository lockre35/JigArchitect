using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jig.JigArchitect.Manual.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PluralName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "EndPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EndPoints_ServiceId",
                table: "EndPoints",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApplicationId",
                table: "Services",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndPoints_Services_ServiceId",
                table: "EndPoints",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndPoints_Services_ServiceId",
                table: "EndPoints");

            migrationBuilder.DropIndex(
                name: "IX_EndPoints_ServiceId",
                table: "EndPoints");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "EndPoints");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
