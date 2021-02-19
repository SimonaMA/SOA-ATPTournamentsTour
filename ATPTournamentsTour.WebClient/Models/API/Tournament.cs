using System;

namespace ATPTournamentsTour.WebClient.Models.Api
{
    public class Tournament
    {
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int TicketPrice { get; set; }
        public string PastChampion { get; set; }
        public DateTime Date { get; set; }
        public string TournamentDescription { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
