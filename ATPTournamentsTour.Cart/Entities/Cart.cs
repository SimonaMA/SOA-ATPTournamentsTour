using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Collection<CartItem> CartItems { get; set; }
    }
}
