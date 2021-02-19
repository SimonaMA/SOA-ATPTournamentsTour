using ATPTournamentsTour.Cart.DbContexts;
using ATPTournamentsTour.Cart.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _cartDbContext;

        public CartRepository(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }         

        public async Task<Entities.Cart> GetCartById(Guid cartId)
        {
            return await _cartDbContext.Carts.Include(c => c.CartItems)
                .Where(ci => ci.CartId == cartId).FirstOrDefaultAsync();
        }

        public async Task<bool> CartExists(Guid cartId)
        {
            return await _cartDbContext.Carts
                .AnyAsync(c => c.CartId == cartId);
        }

        public void AddCart(Entities.Cart cart)
        {
            _cartDbContext.Carts.Add(cart);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _cartDbContext.SaveChangesAsync() > 0);
        }
    }
}
