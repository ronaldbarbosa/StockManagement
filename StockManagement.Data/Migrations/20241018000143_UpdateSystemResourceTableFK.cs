using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSystemResourceTableFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemResource_SystemResource_SystemResourceId",
                table: "SystemResource");

            migrationBuilder.RenameColumn(
                name: "SystemResourceId",
                table: "SystemResource",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemResource_SystemResourceId",
                table: "SystemResource",
                newName: "IX_SystemResource_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemResource_SystemResource_ParentId",
                table: "SystemResource",
                column: "ParentId",
                principalTable: "SystemResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemResource_SystemResource_ParentId",
                table: "SystemResource");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "SystemResource",
                newName: "SystemResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemResource_ParentId",
                table: "SystemResource",
                newName: "IX_SystemResource_SystemResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemResource_SystemResource_SystemResourceId",
                table: "SystemResource",
                column: "SystemResourceId",
                principalTable: "SystemResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
