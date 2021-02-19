using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATPTournamentsTour.Cart.Migrations
{
    public partial class CartItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: new Guid("75918bea-7a04-406e-bafd-51dc8b98816f"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: new Guid("bec71e6b-6b3d-444e-85d7-77bdb3988908"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.AddColumn<int>(
                name: "TicketPrice",
                table: "CartItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "CartItems");

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
        }
    }
}
