using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureLayer.Migrations
{
    public partial class tests222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 18, 23, 26, 47, 887, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 20, 23, 26, 47, 888, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 4, 19, 23, 26, 47, 888, DateTimeKind.Local).AddTicks(9522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 18, 22, 21, 12, 1, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 20, 22, 21, 12, 2, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 4, 19, 22, 21, 12, 2, DateTimeKind.Local).AddTicks(3274));
        }
    }
}
