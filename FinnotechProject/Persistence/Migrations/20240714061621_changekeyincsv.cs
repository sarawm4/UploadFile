using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changekeyincsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_csvFiles",
                table: "csvFiles");

            migrationBuilder.DropIndex(
                name: "IX_csvFiles_Code",
                table: "csvFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "csvFiles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "csvFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 14, 9, 46, 21, 434, DateTimeKind.Local).AddTicks(8417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 14, 11, 5, 35, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "csvFiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_csvFiles",
                table: "csvFiles",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_csvFiles",
                table: "csvFiles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "csvFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 14, 11, 5, 35, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 14, 9, 46, 21, 434, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "csvFiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "csvFiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csvFiles",
                table: "csvFiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_csvFiles_Code",
                table: "csvFiles",
                column: "Code",
                unique: true);
        }
    }
}
