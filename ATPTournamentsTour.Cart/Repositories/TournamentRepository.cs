using System;
using System.Threading.Tasks;
using ATPTournamentsTour.Cart.DbContexts;
using ATPTournamentsTour.Cart.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATPTournamentsTour.Cart.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly CartDbContext _cartDbContext;

        public TournamentRepository(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        public async Task<bool> TournamentExists(Guid tournamentId)
        {
            return await _cartDbContext.Tournaments.AnyAsync(t => t.TournamentId == tournamentId);
        }

        public void AddTournament(Tournament tournament)
        {
            _cartDbContext.Tournaments.Add(tournament);

        }

        public async Task<bool> SaveChanges()
        {
            return (await _cartDbContext.SaveChangesAsync() > 0);
        }
    }
}
