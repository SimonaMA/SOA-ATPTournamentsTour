using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ATPTournamentsTour.Cart.Models;
using ATPTournamentsTour.Cart.Repositories;
using ATPTournamentsTour.Cart.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATPTournamentsTour.Cart.Controllers
{
    [Route("api/carts/{cartId}/cartitems")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public CartItemsController(ICartRepository cartRepository, 
            ICartItemsRepository cartItemsRepository, ITournamentRepository tournamentRepository, 
            ITournamentService tournamentService, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartItemsRepository = cartItemsRepository;
            _tournamentRepository = tournamentRepository;
            _tournamentService = tournamentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> Get(Guid cartId)
        {
            if (!await _cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartItems = await _cartItemsRepository.GetCartItems(cartId);
            return Ok(_mapper.Map<IEnumerable<CartItem>>(cartItems));             
        }

        [HttpGet("{cartItemId}", Name = "GetCartItem")]
        public async Task<ActionResult<CartItem>> Get(Guid cartId, 
            Guid cartItemId)
        {
            if (!await _cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartItem = await _cartItemsRepository.GetCartItemById(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CartItem>(cartItem));
        }

        [HttpPost]
        public async Task<ActionResult<CartItem>> Post(Guid cartId, 
            [FromBody] CartItemForCreation cartItemForCreation)
        {
            if (!await _cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            if (!await _tournamentRepository.TournamentExists(cartItemForCreation.TournamentId))
            {
                var tournament = await _tournamentService.GetTournament(cartItemForCreation.TournamentId);
                _tournamentRepository.AddTournament(tournament);
                await _tournamentRepository.SaveChanges();
            }

            var cartItem = _mapper.Map<Entities.CartItem>(cartItemForCreation);

            var processedCartItem = await _cartItemsRepository.AddOrUpdateCartItem(cartId, cartItem);
            await _cartItemsRepository.SaveChanges();

            var cartItemToReturn = _mapper.Map<CartItem>(processedCartItem);

            return CreatedAtRoute(
                "GetCartItem",
                new { cartId = cartItem.CartId, cartItemId = cartItem.CartItemId },
                cartItemToReturn);
        } 

        [HttpPut("{cartItemId}")]
        public async Task<ActionResult<CartItem>> Put(Guid cartId, 
            Guid cartItemId, 
            [FromBody] CartItemForUpdate cartItemForUpdate)
        {
            if (!await _cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartItem = await _cartItemsRepository.GetCartItemById(cartItemId);

            if (cartItem == null)
            {
                return NotFound();
            }

            // map the entity to a dto
            // apply the updated field values to that dto
            // map the dto back to an entity
            _mapper.Map(cartItemForUpdate, cartItem);

            _cartItemsRepository.UpdateCartItem(cartItem);
            await _cartItemsRepository.SaveChanges();

            return Ok(_mapper.Map<CartItem>(cartItem));
        } 

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> Delete(Guid cartId, 
            Guid cartItemId)
        {
            if (!await _cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartItem = await _cartItemsRepository.GetCartItemById(cartItemId);

            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemsRepository.RemoveCartItem(cartItem);
            await _cartItemsRepository.SaveChanges();

            return NoContent();
        }
    }
}
