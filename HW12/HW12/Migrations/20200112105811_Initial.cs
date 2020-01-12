using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HW12.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HasPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "HasPaid" },
                values: new object[] { new Guid("903275db-7a98-438f-80fc-648dbb6f0527"), false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasketId", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("3b3c14f9-1e2d-4f8a-a05a-9ef6d2cb0bc9"), null, 250, "Pepsi" },
                    { new Guid("eabac71d-a6ac-4b04-a7b8-f0094eb1d0f4"), null, 150, "Cola" },
                    { new Guid("64dbe577-5f83-4133-9e7e-3b815f4b5db8"), null, 200, "Snickers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketId",
                table: "Products",
                column: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
