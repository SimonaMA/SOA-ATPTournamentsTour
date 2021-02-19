using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Models.API
{
    public class CartItemForCreation
    {
        [Required]
        public Guid TournamentId { get; set; }
        [Required]
        public int TicketAmount { get; set; }
        [Required]
        public int TicketPrice { get; set; }
    }
}
