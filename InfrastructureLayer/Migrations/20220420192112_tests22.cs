using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureLayer.Migrations
{
    public partial class tests22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidataEntity_Order_OrderEntityId",
                table: "ValidataEntity");

            migrationBuilder.DropIndex(
                name: "IX_ValidataEntity_OrderEntityId",
                table: "ValidataEntity");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "ValidataEntity");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "ValidataEntity",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 18, 21, 56, 23, 572, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 20, 21, 56, 23, 573, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "ValidataEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 4, 19, 21, 56, 23, 573, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.CreateIndex(
                name: "IX_ValidataEntity_OrderEntityId",
                table: "ValidataEntity",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValidataEntity_Order_OrderEntityId",
                table: "ValidataEntity",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
