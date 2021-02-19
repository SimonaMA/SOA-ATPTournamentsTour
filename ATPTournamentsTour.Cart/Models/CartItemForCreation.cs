using System;
using System.ComponentModel.DataAnnotations;

namespace ATPTournamentsTour.Cart.Models
{
    public class CartItemForCreation
    { 
        [Required]
        public Guid TournamentId { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
