using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATPTournamentsTour.Cart.Migrations
{
    public partial class Tournaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TournamentId",
                table: "CartItems",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tournaments_TournamentId",
                table: "CartItems",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tournaments_TournamentId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TournamentId",
                table: "CartItems");
        }
    }
}
