using System;

namespace ATPTournamentsTour.Cart.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Guid TournamentId { get; set; }
        public int TicketPrice { get; set; }
        public int TicketAmount { get; set; }
        public Tournament Tournament { get; set; }
    }
} 
