using System;
using System.Collections.Generic;
using ATPTournamentsTour.WebClient.Models.Api;

namespace ATPTournamentsTour.WebClient.Models.View
{
    public class TournamentsListModel
    {
        public IEnumerable<Tournament> Tournaments { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}
