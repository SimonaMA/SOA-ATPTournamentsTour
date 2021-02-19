using AutoMapper;

namespace ATPTournamentsTour.Cart.Profiles
{
    public class TournamentProfile: Profile
    {
        public TournamentProfile()
        {
            CreateMap<Entities.Tournament, Models.Tournament>().ReverseMap();
        }
    }
}
