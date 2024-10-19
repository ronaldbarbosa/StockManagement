using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSystemResourceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SystemResource",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "SystemResource",
                type: "NVARCHAR(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SystemResource");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "SystemResource");
        }
    }
}
