using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATPTournamentsTour.Cart.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<Models.CartItemForCreation, Entities.CartItem>();
            CreateMap<Models.CartItemForUpdate, Entities.CartItem>();
            CreateMap<Entities.CartItem, Models.CartItem>().ReverseMap();

        }
    }
}
