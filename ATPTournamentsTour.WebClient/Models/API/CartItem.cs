using ATPTournamentsTour.WebClient.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Models.API
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Guid TournamentId { get; set; }
        public int TicketAmount { get; set; }
        public int TicketPrice { get; set; }
        public Tournament Tournament { get; set; }
    }
}
