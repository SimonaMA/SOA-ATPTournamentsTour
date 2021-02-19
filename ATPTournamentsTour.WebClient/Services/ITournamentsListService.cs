using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATPTournamentsTour.WebClient.Models.Api;

namespace ATPTournamentsTour.WebClient.Services
{
    public interface ITournamentsListService
    {
        Task<IEnumerable<Tournament>> GetAll();
        Task<IEnumerable<Tournament>> GetByCategoryId(Guid categoryid);
        Task<Tournament> GetTournament(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
