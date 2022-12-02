using ArtistsCatalog.API.Application.Responses;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using AutoMapper;

namespace ArtistsCatalog.API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Artist, ArtistDTO>();
        }
    }
}
