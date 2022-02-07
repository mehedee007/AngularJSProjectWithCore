using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSProjectWithCore.Data.Migrations
{
    public partial class NullablePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Devices",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Devices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Devices",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Devices",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Categories_CategoryId",
                table: "Devices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
