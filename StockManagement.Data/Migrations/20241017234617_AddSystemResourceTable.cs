using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemResourceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    SystemResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemResource_SystemResource_SystemResourceId",
                        column: x => x.SystemResourceId,
                        principalTable: "SystemResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemResource_SystemResourceId",
                table: "SystemResource",
                column: "SystemResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemResource");
        }
    }
}
