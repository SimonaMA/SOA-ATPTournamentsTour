using System;
using System.Collections.Generic;

namespace ATPTournamentsTour.TournamentsList.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}
