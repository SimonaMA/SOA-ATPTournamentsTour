using System;
using ATPTournamentsTour.TournamentsList.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATPTournamentsTour.TournamentsList.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetTournaments(Guid categoryId);
        Task<Tournament> GetTournamentById(Guid tournamentId);
    }
}
