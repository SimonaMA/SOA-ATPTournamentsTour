using System;
using System.Net.Http;
using System.Threading.Tasks;
using ATPTournamentsTour.Cart.Entities;
using ATPTournamentsTour.Cart.Extensions;

namespace ATPTournamentsTour.Cart.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly HttpClient client;

        public TournamentService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Tournament> GetTournament(Guid id)
        {
            var response = await client.GetAsync($"/api/tournaments/{id}");
            return await response.ReadContentAs<Tournament>();
        }
    }
}
