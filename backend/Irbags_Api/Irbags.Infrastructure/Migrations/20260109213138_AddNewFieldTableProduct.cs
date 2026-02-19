using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irbags.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "ProductImages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "ProductImages");
        }
    }
}
