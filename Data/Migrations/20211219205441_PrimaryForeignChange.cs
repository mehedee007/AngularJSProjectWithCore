using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSProjectWithCore.Data.Migrations
{
    public partial class PrimaryForeignChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Devices_DeviceID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeviceID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Devices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CategoryID",
                table: "Devices",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Categories_CategoryID",
                table: "Devices",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Categories_CategoryID",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CategoryID",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeviceID",
                table: "Categories",
                column: "DeviceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Devices_DeviceID",
                table: "Categories",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
