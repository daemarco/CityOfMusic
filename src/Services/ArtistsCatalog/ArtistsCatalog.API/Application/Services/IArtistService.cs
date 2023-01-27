using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Responses;

namespace ArtistsCatalog.API.Application.Services
{
    public interface IArtistService
    {
        Task<ArtistDTO> AddArtist(AddArtistRequest request);
    }
}
