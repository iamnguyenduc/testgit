using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRazorProject.Migrations
{
    /// <inheritdoc />
    public partial class AddTextFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "AboutList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "AboutList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text1",
                table: "AboutList");

            migrationBuilder.DropColumn(
                name: "Text2",
                table: "AboutList");
        }
    }
}
