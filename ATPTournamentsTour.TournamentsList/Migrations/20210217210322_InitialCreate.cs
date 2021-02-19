using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATPTournamentsTour.TournamentsList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                column: "Date",
                value: new DateTime(2021, 8, 17, 23, 3, 22, 505, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                column: "Date",
                value: new DateTime(2021, 10, 17, 23, 3, 22, 508, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                column: "Date",
                value: new DateTime(2021, 11, 17, 23, 3, 22, 508, DateTimeKind.Local).AddTicks(1590));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                column: "Date",
                value: new DateTime(2021, 8, 17, 23, 1, 58, 633, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                column: "Date",
                value: new DateTime(2021, 10, 17, 23, 1, 58, 635, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                column: "Date",
                value: new DateTime(2021, 11, 17, 23, 1, 58, 635, DateTimeKind.Local).AddTicks(3322));
        }
    }
}
