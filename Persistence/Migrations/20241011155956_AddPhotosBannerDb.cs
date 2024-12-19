using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotosBannerDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
