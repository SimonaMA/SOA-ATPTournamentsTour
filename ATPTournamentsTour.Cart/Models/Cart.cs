using System;

namespace ATPTournamentsTour.Cart.Models
{
    public class Cart
    {        
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
    }
}
