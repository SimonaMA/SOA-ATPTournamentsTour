using System.ComponentModel.DataAnnotations;

namespace ATPTournamentsTour.Cart.Models
{
    public class CartItemForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
