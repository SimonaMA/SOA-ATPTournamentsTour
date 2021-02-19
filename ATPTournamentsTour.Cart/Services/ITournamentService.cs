using System;
using System.Threading.Tasks;
using ATPTournamentsTour.Cart.Entities;

namespace ATPTournamentsTour.Cart.Services
{
    public interface ITournamentService
    {
        Task<Tournament> GetTournament(Guid id);
    }
}