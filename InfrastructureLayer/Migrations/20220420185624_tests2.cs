using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureLayer.Migrations
{
    public partial class tests2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Product = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidataEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidataEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidataEntity_Order_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidataEntity_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ValidataEntity",
                columns: new[] { "Id", "Adress", "Date", "LastName", "Name", "Number", "OrderEntityId", "OrderId", "PostalCode" },
                values: new object[] { 1, "Test", new DateTime(2022, 4, 18, 21, 56, 23, 572, DateTimeKind.Local).AddTicks(2887), "Ozbey", "Andriy", 3, null, null, 123 });

            migrationBuilder.InsertData(
                table: "ValidataEntity",
                columns: new[] { "Id", "Adress", "Date", "LastName", "Name", "Number", "OrderEntityId", "OrderId", "PostalCode" },
                values: new object[] { 3, "Test", new DateTime(2022, 4, 19, 21, 56, 23, 573, DateTimeKind.Local).AddTicks(3656), "Ozbey", "Oyku", 3, null, null, 123 });

            migrationBuilder.InsertData(
                table: "ValidataEntity",
                columns: new[] { "Id", "Adress", "Date", "LastName", "Name", "Number", "OrderEntityId", "OrderId", "PostalCode" },
                values: new object[] { 2, "Test", new DateTime(2022, 4, 20, 21, 56, 23, 573, DateTimeKind.Local).AddTicks(3678), "Ozbey", "Arif", 3, null, null, 123 });

            migrationBuilder.CreateIndex(
                name: "IX_ValidataEntity_OrderEntityId",
                table: "ValidataEntity",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidataEntity_OrderId",
                table: "ValidataEntity",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidataEntity");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
