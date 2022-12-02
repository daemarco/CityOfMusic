using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Responses;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using AutoMapper;

namespace ArtistsCatalog.API.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //TODO-Marco - Check for validations, should reside in Domain Model
        public async Task<ArtistDTO> AddArtistRequest(AddArtistRequest request)
        {
            var artist = new Artist(request.Name);
            foreach (var member in request.Members)
            {
                artist.AddArtistMember(member.Name, member.Surname);
            }

            _repository.Add(artist);

            await _repository.UnitOfWork.SaveChangesAsync();//.SaveEntitiesAsync();

            //Map back result
            return _mapper.Map<ArtistDTO>(artist);
        }
    }
}
