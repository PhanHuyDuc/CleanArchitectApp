using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangebannerDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Banners_BannerId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BannerId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BannerId",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Banners");

            migrationBuilder.AddColumn<Guid>(
                name: "BannerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BannerId",
                table: "Photos",
                column: "BannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Banners_BannerId",
                table: "Photos",
                column: "BannerId",
                principalTable: "Banners",
                principalColumn: "Id");
        }
    }
}
