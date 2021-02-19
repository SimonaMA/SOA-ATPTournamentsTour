using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }

        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        [Required]
        public int TicketAmount { get; set; }

        [Required]
        public int TicketPrice { get; set; }

        public Cart Cart { get; set; }
    }
}
