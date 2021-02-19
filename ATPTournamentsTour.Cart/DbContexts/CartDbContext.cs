using ATPTournamentsTour.Cart.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATPTournamentsTour.Cart.DbContexts
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
        : base(options)
        {
        }

        public DbSet<Entities.Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
