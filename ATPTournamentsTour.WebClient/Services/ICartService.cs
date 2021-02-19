using ATPTournamentsTour.WebClient.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Services
{
    public interface ICartService
    {
        Task<CartItem> AddToCart(Guid cartId, CartItemForCreation cartItem);
        Task<IEnumerable<CartItem>> GetItemsForCart(Guid cartId);
        Task<Cart> GetCart(Guid cartId);
        Task UpdateItem(Guid cartId, CartItemForUpdate cartItemForUpdate);
        Task RemoveItem(Guid cartId, Guid itemId);
    }
}
