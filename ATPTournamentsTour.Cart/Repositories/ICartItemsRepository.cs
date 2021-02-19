using ATPTournamentsTour.Cart.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Repositories
{
    public interface ICartItemsRepository
    {
        Task<IEnumerable<CartItem>> GetCartItems(Guid cartId);

        Task<CartItem> GetCartItemById(Guid cartItemId);

        Task<CartItem> AddOrUpdateCartItem(Guid cartId, CartItem cartItem);

        void UpdateCartItem(CartItem cartItem);

        void RemoveCartItem(CartItem cartItem);

        Task<bool> SaveChanges();
    }
}