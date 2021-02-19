using System;
using System.ComponentModel.DataAnnotations;

namespace ATPTournamentsTour.Cart.Models
{
    public class CartForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
