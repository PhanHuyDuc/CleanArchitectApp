using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWebInforname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebsiteInformations");

            migrationBuilder.CreateTable(
                name: "WebsiteInfors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebsiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAdminTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteInfors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebsiteInfors");

            migrationBuilder.CreateTable(
                name: "WebsiteInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAdminTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteEmail3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePhoneNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteInformations", x => x.Id);
                });
        }
    }
}
