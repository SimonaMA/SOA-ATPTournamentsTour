using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATPTournamentsTour.TournamentsList.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CategoryId", "Date" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"), new DateTime(2021, 10, 17, 23, 1, 58, 635, DateTimeKind.Local).AddTicks(3409) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                columns: new[] { "CategoryId", "Date" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), new DateTime(2021, 11, 17, 23, 1, 58, 635, DateTimeKind.Local).AddTicks(3322) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                column: "Date",
                value: new DateTime(2021, 8, 14, 23, 26, 37, 303, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                columns: new[] { "CategoryId", "Date" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), new DateTime(2021, 10, 14, 23, 26, 37, 305, DateTimeKind.Local).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                columns: new[] { "CategoryId", "Date" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2021, 11, 14, 23, 26, 37, 305, DateTimeKind.Local).AddTicks(8991) });
        }
    }
}
