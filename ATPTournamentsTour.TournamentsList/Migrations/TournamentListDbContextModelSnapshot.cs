﻿// <auto-generated />
using System;
using ATPTournamentsTour.TournamentsList.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATPTournamentsTour.TournamentsList.Migrations
{
    [DbContext(typeof(TournamentListDbContext))]
    partial class TournamentListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATPTournamentsTour.TournamentsList.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            CategoryName = "Grand Slam"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            CategoryName = "ATP World Tour Masters 1000"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"),
                            CategoryName = "ATP Tour 500"
                        });
                });

            modelBuilder.Entity("ATPTournamentsTour.TournamentsList.Entities.Tournament", b =>
                {
                    b.Property<Guid>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastChampion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.Property<string>("TournamentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournamentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TournamentId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            TournamentId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Date = new DateTime(2021, 8, 17, 23, 3, 22, 505, DateTimeKind.Local).AddTicks(7553),
                            ImageUrl = "/img/Australian.jpg",
                            PastChampion = "Novak Djokovic",
                            TicketPrice = 200,
                            TournamentDescription = "The Australian Open is a tennis tournament held annually at Melbourne Park in Melbourne, Australia. The tournament is the first of the four Grand Slam tennis events held each year, preceding the French Open, Wimbledon, and the US Open. Often referred to as the Grand Slam of Asia / Pacific, the tournament is the highest attended Grand Slam event, with more than 812,000 people attending the 2020 tournament.",
                            TournamentName = "Australian Open"
                        },
                        new
                        {
                            TournamentId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            Date = new DateTime(2021, 11, 17, 23, 3, 22, 508, DateTimeKind.Local).AddTicks(1590),
                            ImageUrl = "/img/Nitto_ATP_Finals_logo.jpg",
                            PastChampion = "Daniil Medvedev",
                            TicketPrice = 100,
                            TournamentDescription = "The ATP Finals is the second highest tier of annual men's tennis tournaments after the four Grand Slam tournaments. A week-long event, the tournament is held annually at the Pala Alpitour in Turin, Italy. The ATP Finals are the season-ending championships of the ATP Tour and feature the top eight singles players and doubles teams of the ATP Rankings.",
                            TournamentName = "ATP World Tour Masters 1000"
                        },
                        new
                        {
                            TournamentId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"),
                            Date = new DateTime(2021, 10, 17, 23, 3, 22, 508, DateTimeKind.Local).AddTicks(1679),
                            ImageUrl = "/img/swiss_indoors.jpg",
                            PastChampion = "Roger Federer",
                            TicketPrice = 70,
                            TournamentDescription = "The Swiss Indoors is a professional men's tennis tournament played on indoor hard courts at the St. Jakobshalle in Basel, Switzerland. Basel native Roger Federer holds the record for most singles titles, having won the tournament ten times.",
                            TournamentName = "Swiss Indoors"
                        });
                });

            modelBuilder.Entity("ATPTournamentsTour.TournamentsList.Entities.Tournament", b =>
                {
                    b.HasOne("ATPTournamentsTour.TournamentsList.Entities.Category", "Category")
                        .WithMany("Tournaments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
