using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATPTournamentsTour.Cart.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(nullable: false),
                    CartId = table.Column<Guid>(nullable: false),
                    TournamentId = table.Column<Guid>(nullable: false),
                    TicketAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "UserId" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("6c9fe94e-257a-42e2-a49c-1b216d4e81be") });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "TournamentId", "TicketAmount" },
                values: new object[] { new Guid("75918bea-7a04-406e-bafd-51dc8b98816f"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("e29f3df4-d9b4-4182-84dc-4289ac17c0c0"), 3 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "TournamentId", "TicketAmount" },
                values: new object[] { new Guid("bec71e6b-6b3d-444e-85d7-77bdb3988908"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("39144996-8bad-4cb8-9029-125d88808377"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
