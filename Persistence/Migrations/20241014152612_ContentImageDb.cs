using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContentImageDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Contents_ContentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ContentId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "ContentImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentImage_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentImage_ContentId",
                table: "ContentImage",
                column: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentImage");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ContentId",
                table: "Photos",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Contents_ContentId",
                table: "Photos",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id");
        }
    }
}
