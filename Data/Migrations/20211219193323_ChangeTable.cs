using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSProjectWithCore.Data.Migrations
{
    public partial class ChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CategoryId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "Devices",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Categories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Devices_DeviceID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeviceID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CategoryId",
                table: "Devices",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
