using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Models.API
{
    public class CartForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
