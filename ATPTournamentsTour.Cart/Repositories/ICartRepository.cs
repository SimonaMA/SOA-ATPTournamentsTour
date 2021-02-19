using ATPTournamentsTour.Cart.Entities;
using System;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Repositories
{
    public interface ICartRepository
    {
        Task<bool> CartExists(Guid cartId);

        Task<Entities.Cart> GetCartById(Guid cartId);

        void AddCart(Entities.Cart cart);

        Task<bool> SaveChanges();
    }
}