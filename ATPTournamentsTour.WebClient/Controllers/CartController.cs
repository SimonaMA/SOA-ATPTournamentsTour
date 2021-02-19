using System;
using System.Linq;
using System.Threading.Tasks;
using ATPTournamentsTour.Messages;
using ATPTournamentsTour.WebClient.Extensions;
using ATPTournamentsTour.WebClient.Models;
using ATPTournamentsTour.WebClient.Models.API;
using ATPTournamentsTour.WebClient.Models.View;
using ATPTournamentsTour.WebClient.Services;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace ATPTournamentsTour.WebClient.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IBus bus;
        private readonly Settings settings;

        public CartController(ICartService cartService, IBus bus, Settings settings)
        {
            this.cartService = cartService;
            this.bus = bus;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await cartService.GetItemsForCart(Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}"));
            var lineViewModels = cartItems.Select(bl => new CartItemViewModel
            {
                ItemId = bl.CartItemId,
                TournamentId = bl.TournamentId,
                TournamentName = bl.Tournament.TournamentName,
                Date = bl.Tournament.Date,
                TicketPrice = bl.TicketPrice,
                Quantity = bl.TicketAmount
            }
            );
            return View(lineViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(CartItemForCreation cartItem)
        {
            var cartId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");
            var newItem = await cartService.AddToCart(cartId, cartItem);
            Response.Cookies.Append(settings.CartIdCookieName, newItem.CartId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(CartItemForUpdate cartItemForUpdate)
        {
            var cartId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");
            await cartService.UpdateItem(cartId, cartItemForUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(Guid itemId)
        {
            var cartId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");
            await cartService.RemoveItem(cartId, itemId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pay()
        {
            var cartId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");
            await bus.Send(new PaymentRequestMessage { CartId = cartId });
            return View("Thanks");
        }
    }
}
