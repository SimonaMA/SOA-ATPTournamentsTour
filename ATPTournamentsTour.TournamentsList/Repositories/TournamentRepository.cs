using ATPTournamentsTour.TournamentsList.DbContexts;
using ATPTournamentsTour.TournamentsList.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.TournamentsList.Repositories
{
    public class TournamentRepository: ITournamentRepository
    {
        private readonly TournamentListDbContext _tournamentsListDbContext;

        public TournamentRepository(TournamentListDbContext tournamentListDbContext)
        {
            _tournamentsListDbContext = tournamentListDbContext;
        }


        public async Task<IEnumerable<Tournament>> GetTournaments(Guid categoryId)
        {
            return await _tournamentsListDbContext.Tournaments
                .Include(x => x.Category)
                .Where(x => (x.CategoryId == categoryId || categoryId == Guid.Empty)).ToListAsync();
        }

        public async Task<Tournament> GetTournamentById(Guid tournamentId)
        {
            return await _tournamentsListDbContext.Tournaments.Include(x => x.Category).Where(x => x.TournamentId == tournamentId).FirstOrDefaultAsync();
        }
    }
}
