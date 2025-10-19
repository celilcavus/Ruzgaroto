using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuzgarOto.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddDynamicContentEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LogoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MenuIcon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDropdown = table.Column<bool>(type: "bit", nullable: false),
                    ParentMenuId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Target = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMainSlider = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SiteKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FaviconName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FooterText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GoogleMapsEmbed = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    GoogleAnalytics = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCompanies_Id",
                table: "InsuranceCompanies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSettings_Id",
                table: "MenuSettings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSliders_Id",
                table: "ServiceSliders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_Id",
                table: "SiteSettings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "MenuSettings");

            migrationBuilder.DropTable(
                name: "ServiceSliders");

            migrationBuilder.DropTable(
                name: "SiteSettings");
        }
    }
}
