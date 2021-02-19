using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ATPTournamentsTour.Cart.Models;
using ATPTournamentsTour.Cart.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace ATPTournamentsTour.Cart.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartsController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet("{cartId}", Name = "GetCart")]
        public async Task<ActionResult<Models.Cart>> Get(Guid cartId)
        {
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Models.Cart>(cart);
            result.NumberOfItems = cart.CartItems.Sum(c => c.TicketAmount);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Cart>> Post(CartForCreation cartForCreation)
        {
            var cart = _mapper.Map<Entities.Cart>(cartForCreation);

            _cartRepository.AddCart(cart);
            await _cartRepository.SaveChanges();

            var cartToReturn = _mapper.Map<Models.Cart>(cart);

            return CreatedAtRoute(
                "GetCart",
                new { cartId = cart.CartId },
                cartToReturn);
        }
    }
}
