using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hakaton.Data.Migrations
{
    public partial class RepairModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Token",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PathPhotos_ServiceId",
                table: "PathPhotos",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PathPhotos_Services_ServiceId",
                table: "PathPhotos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PathPhotos_Services_ServiceId",
                table: "PathPhotos");

            migrationBuilder.DropIndex(
                name: "IX_PathPhotos_ServiceId",
                table: "PathPhotos");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Services");
        }
    }
}
