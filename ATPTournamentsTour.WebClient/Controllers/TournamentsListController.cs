using System;
using System.Threading.Tasks;
using ATPTournamentsTour.WebClient.Extensions;
using ATPTournamentsTour.WebClient.Models;
using ATPTournamentsTour.WebClient.Models.Api;
using ATPTournamentsTour.WebClient.Models.API;
using ATPTournamentsTour.WebClient.Models.View;
using ATPTournamentsTour.WebClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATPTournamentsTour.WebClient.Controllers
{
    public class TournamentsListController : Controller
    {
        private readonly ITournamentsListService tournamentListService;
        private readonly Settings settings;
        private readonly ICartService cartService;

        public TournamentsListController(ITournamentsListService tournamentListService, Settings settings, ICartService cartService)
        {
            this.tournamentListService = tournamentListService;
            this.settings = settings;
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var currentCartId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");

            var cart = currentCartId == Guid.Empty ? Task.FromResult<Cart>(null) :
                cartService.GetCart(currentCartId);

            var categories = tournamentListService.GetCategories();
            var tournaments = categoryId == Guid.Empty ? tournamentListService.GetAll() : tournamentListService.GetByCategoryId(categoryId);
            await Task.WhenAll(new Task[] {cart, categories, tournaments });

            return View(
                new TournamentsListModel
                {
                    Tournaments = tournaments.Result,
                    Categories = categories.Result,
                    SelectedCategory = categoryId,
                    NumberOfItems = cart.Result == null ? 0 : cart.Result.NumberOfItems
        }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm]Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid tournamentId)
        {
            var ev = await tournamentListService.GetTournament(tournamentId);
            return View(ev);
        }
    }
}
