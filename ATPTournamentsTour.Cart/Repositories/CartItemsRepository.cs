using ATPTournamentsTour.Cart.DbContexts;
using ATPTournamentsTour.Cart.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Repositories
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly CartDbContext _cartDbContext;

        public CartItemsRepository(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(Guid cartId)
        {
            return await _cartDbContext.CartItems.Include(c => c.Tournament)
                .Where(b => b.CartId == cartId).ToListAsync();
        }

        public async Task<CartItem> GetCartItemById(Guid cartItemId)
        {
            return await _cartDbContext.CartItems.Include(c => c.Tournament)
                .Where(b => b.CartItemId == cartItemId).FirstOrDefaultAsync();
        }

        public async Task<CartItem> AddOrUpdateCartItem(Guid cartId, CartItem cartItem)
        {
            var existingItem = await _cartDbContext.CartItems.Include(c => c.Tournament)
                .Where(b => b.CartId == cartId && b.TournamentId == cartItem.TournamentId).FirstOrDefaultAsync();
            if (existingItem == null)
            {
                cartItem.CartId = cartId;
                _cartDbContext.CartItems.Add(cartItem);
                return cartItem;
            }
            existingItem.TicketAmount += cartItem.TicketAmount;
            return existingItem;
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            // empty on purpose
        }
        
        public void RemoveCartItem(CartItem cartItem)
        {
            _cartDbContext.CartItems.Remove(cartItem);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _cartDbContext.SaveChangesAsync() > 0);
        }
    }
}
