using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StillAboutbannerPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Photos_PhotoId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_PhotoId",
                table: "Banners");

            migrationBuilder.AddColumn<Guid>(
                name: "BannerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoId",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "PhotoId",
                table: "Banners",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_PhotoId",
                table: "Banners",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Photos_PhotoId",
                table: "Banners",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
