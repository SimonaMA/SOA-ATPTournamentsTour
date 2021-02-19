using ATPTournamentsTour.WebClient.Extensions;
using ATPTournamentsTour.WebClient.Models;
using ATPTournamentsTour.WebClient.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ATPTournamentsTour.WebClient.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient client;
        private readonly Settings settings;

        public CartService(HttpClient client, Settings settings)
        {
            this.client = client;
            this.settings = settings;
        }

        public async Task<CartItem> AddToCart(Guid cartId, CartItemForCreation cartItem)
        {
            if (cartId == Guid.Empty)
            {
                var cartResponse = await client.PostAsJson("/api/carts", new CartForCreation { UserId = settings.UserId });
                var cart = await cartResponse.ReadContentAs<Cart>();
                cartId = cart.CartId;
            }

            var response = await client.PostAsJson($"api/carts/{cartId}/cartitems", cartItem);
            return await response.ReadContentAs<CartItem>();
        }

        public async Task<Cart> GetCart(Guid cartId)
        {
            if (cartId == Guid.Empty)
                return null;
            var response = await client.GetAsync($"/api/carts/{cartId}");
            return await response.ReadContentAs<Cart>();
        }

        public async Task<IEnumerable<CartItem>> GetItemsForCart(Guid cartId)
        {
            if (cartId == Guid.Empty)
                return new CartItem[0];
            var response = await client.GetAsync($"/api/carts/{cartId}/cartitems");
            return await response.ReadContentAs<CartItem[]>();

        }

        public async Task UpdateItem(Guid cartId, CartItemForUpdate cartItemForUpdate)
        {
            await client.PutAsJson($"/api/carts/{cartId}/cartitems/{cartItemForUpdate.ItemId}", cartItemForUpdate);
        }

        public async Task RemoveItem(Guid cartId, Guid itemId)
        {
            await client.DeleteAsync($"/api/carts/{cartId}/cartitems/{itemId}");
        }
    }
}
