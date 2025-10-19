using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuzgarOto.Web.Migrations
{
    /// <inheritdoc />
    public partial class contactPhonePropChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Contacts",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "PhoneNumber");
        }
    }
}
