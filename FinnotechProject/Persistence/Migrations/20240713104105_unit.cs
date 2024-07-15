using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class unit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "csvFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 14, 11, 5, 35, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 12, 13, 44, 48, 668, DateTimeKind.Local).AddTicks(7136));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "csvFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 12, 13, 44, 48, 668, DateTimeKind.Local).AddTicks(7136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 14, 11, 5, 35, DateTimeKind.Local).AddTicks(8092));
        }
    }
}
