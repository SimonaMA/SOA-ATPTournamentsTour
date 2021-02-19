using System;
using System.Collections.Generic;
using System.Linq;

namespace ATPTournamentsTour.WebClient.Extensions
{
    public static class EnumerableOfGuid
    {
        public static string ToQueryString(this IEnumerable<Guid> guids)
        {
            return "?" + string.Join("&", guids.Select(g => $"tournamentIds={g}"));
        }
    }
}
