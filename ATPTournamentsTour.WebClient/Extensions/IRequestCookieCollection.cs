using System;
using ATPTournamentsTour.WebClient.Models;
using Microsoft.AspNetCore.Http;

namespace ATPTournamentsTour.WebClient.Extensions
{
    public static  class RequestCookieCollection
    {
        public static Guid GetCurrentCartId(this IRequestCookieCollection cookies, Settings settings)
        {
            Guid.TryParse(cookies[settings.CartIdCookieName], out Guid cartId);
            return cartId;
        }
    }
}
