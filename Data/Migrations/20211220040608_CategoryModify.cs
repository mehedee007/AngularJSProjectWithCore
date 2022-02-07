using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSProjectWithCore.Data.Migrations
{
    public partial class CategoryModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Categories");
        }
    }
}
