using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContentImgDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentImage_Contents_ContentId",
                table: "ContentImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage");

            migrationBuilder.RenameTable(
                name: "ContentImage",
                newName: "ContentImages");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImage_ContentId",
                table: "ContentImages",
                newName: "IX_ContentImages_ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentImages_Contents_ContentId",
                table: "ContentImages",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentImages_Contents_ContentId",
                table: "ContentImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages");

            migrationBuilder.RenameTable(
                name: "ContentImages",
                newName: "ContentImage");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImages_ContentId",
                table: "ContentImage",
                newName: "IX_ContentImage_ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentImage_Contents_ContentId",
                table: "ContentImage",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
