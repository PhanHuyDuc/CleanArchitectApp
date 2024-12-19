using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCOntentAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Authors_AuthorId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_AuthorId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Contents");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Contents");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Contents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_AuthorId",
                table: "Contents",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Authors_AuthorId",
                table: "Contents",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
