using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ATPTournamentsTour.WebClient.Extensions;
using ATPTournamentsTour.WebClient.Models.Api;

namespace ATPTournamentsTour.WebClient.Services
{
    public class TournamentsListService : ITournamentsListService
    {
        private readonly HttpClient client;

        public TournamentsListService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Tournament>> GetAll()
        {
            var response = await client.GetAsync("/api/tournaments");
            response.EnsureSuccessStatusCode();
            return await response.ReadContentAs<List<Tournament>>();
        }

        public async Task<IEnumerable<Tournament>> GetByCategoryId(Guid categoryid)
        {
            var response = await client.GetAsync($"/api/tournaments/?categoryId={categoryid}");
            response.EnsureSuccessStatusCode();
            return await response.ReadContentAs<List<Tournament>>();
        }

        public async Task<Tournament> GetTournament(Guid id)
        {
            var response = await client.GetAsync($"/api/tournaments/{id}");
            response.EnsureSuccessStatusCode();
            return await response.ReadContentAs<Tournament>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await client.GetAsync("/api/categories");
            return await response.ReadContentAs<List<Category>>();
        }

    }
}
