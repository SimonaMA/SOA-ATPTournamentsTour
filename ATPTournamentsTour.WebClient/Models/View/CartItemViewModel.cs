using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Models.View
{
    public class CartItemViewModel
    {
        public Guid ItemId { get; set; }
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public DateTimeOffset Date { get; set; }
        public int TicketPrice { get; set; }
        public int Quantity { get; set; }
    }
}
