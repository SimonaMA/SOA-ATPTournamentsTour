using System;
using ATPTournamentsTour.TournamentsList.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATPTournamentsTour.TournamentsList.DbContexts
{
    public class TournamentListDbContext : DbContext
    {
        public TournamentListDbContext(DbContextOptions<TournamentListDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var grandSlamGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}");
            var atpWorldTourMastersGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA315}");
            var atpTour500Guid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA316}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = grandSlamGuid,
                CategoryName = "Grand Slam"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = atpWorldTourMastersGuid,
                CategoryName = "ATP World Tour Masters 1000"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = atpTour500Guid,
                CategoryName = "ATP Tour 500"
            });

            modelBuilder.Entity<Tournament>().HasData(new Tournament
            {
                TournamentId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
                TournamentName = "Australian Open",
                TicketPrice = 200,
                PastChampion = "Novak Djokovic",
                Date = DateTime.Now.AddMonths(6),
                TournamentDescription = "The Australian Open is a tennis tournament held annually at Melbourne Park in Melbourne, Australia. The tournament is the first of the four Grand Slam tennis events held each year, preceding the French Open, Wimbledon, and the US Open. Often referred to as the Grand Slam of Asia / Pacific, the tournament is the highest attended Grand Slam event, with more than 812,000 people attending the 2020 tournament.",
                ImageUrl = "/img/Australian.jpg",
                CategoryId = grandSlamGuid
            });

            modelBuilder.Entity<Tournament>().HasData(new Tournament
            {
                TournamentId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
                TournamentName = "ATP World Tour Masters 1000",
                TicketPrice = 100,
                PastChampion = "Daniil Medvedev",
                Date = DateTime.Now.AddMonths(9),
                TournamentDescription = "The ATP Finals is the second highest tier of annual men's tennis tournaments after the four Grand Slam tournaments. A week-long event, the tournament is held annually at the Pala Alpitour in Turin, Italy. The ATP Finals are the season-ending championships of the ATP Tour and feature the top eight singles players and doubles teams of the ATP Rankings.",
                ImageUrl = "/img/Nitto_ATP_Finals_logo.jpg",
                CategoryId = atpWorldTourMastersGuid
            });


            modelBuilder.Entity<Tournament>().HasData(new Tournament
            {
                TournamentId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
                TournamentName = "Swiss Indoors",
                TicketPrice = 70,
                PastChampion = "Roger Federer",
                Date = DateTime.Now.AddMonths(8),
                TournamentDescription = "The Swiss Indoors is a professional men's tennis tournament played on indoor hard courts at the St. Jakobshalle in Basel, Switzerland. Basel native Roger Federer holds the record for most singles titles, having won the tournament ten times.",
                ImageUrl = "/img/swiss_indoors.jpg",
                CategoryId = atpTour500Guid
            });    
        }
    }

}
