using System;
using System.Threading.Tasks;
using ATPTournamentsTour.Cart.Entities;

namespace ATPTournamentsTour.Cart.Repositories
{
    public interface ITournamentRepository
    {
        void AddTournament(Tournament tournament);
        Task<bool> TournamentExists(Guid tournamentId);
        Task<bool> SaveChanges();
    }
}