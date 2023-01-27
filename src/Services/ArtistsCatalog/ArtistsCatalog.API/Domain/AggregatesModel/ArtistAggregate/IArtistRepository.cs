using ArtistsCatalog.API.Domain.SeedWork;

namespace ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist Add(Artist artist); 
        
        string[] GetAllArtistNames();
    }
}
