using System;

namespace ATPTournamentsTour.Cart.Entities
{
    public class Tournament
    {
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }
    }
}
