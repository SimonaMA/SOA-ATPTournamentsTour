using AutoMapper;

namespace ATPTournamentsTour.TournamentsList.Profiles
{
    public class TournamentProfile: Profile
    {
        public TournamentProfile()
        {
            CreateMap<Entities.Tournament, Models.TournamentDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.CategoryName));
        }
    }
}
