using ATPTournamentsTour.TournamentsList.DbContexts;
using ATPTournamentsTour.TournamentsList.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.TournamentsList.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly TournamentListDbContext _tournamentsListDbContext;

        public CategoryRepository(TournamentListDbContext tournamentListDbContext)
        {
            _tournamentsListDbContext = tournamentListDbContext;
        }


        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _tournamentsListDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            return await _tournamentsListDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}
