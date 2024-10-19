using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSystemResourceTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SystemResource",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "#",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(300)",
                oldMaxLength: 300,
                oldDefaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SystemResource",
                type: "NVARCHAR(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)",
                oldMaxLength: 200,
                oldDefaultValue: "#");
        }
    }
}
