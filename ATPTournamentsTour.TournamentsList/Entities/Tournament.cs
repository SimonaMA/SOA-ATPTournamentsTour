using System;
using System.ComponentModel.DataAnnotations;

namespace ATPTournamentsTour.TournamentsList.Entities
{
    public class Tournament
    {
        [Required]
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int TicketPrice { get; set; }
        public string PastChampion { get; set; }
        public DateTime Date { get; set; }
        public string TournamentDescription { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
