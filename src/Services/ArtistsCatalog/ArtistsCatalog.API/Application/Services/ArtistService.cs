using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Responses;
using ArtistsCatalog.API.Application.Validations;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using AutoMapper;
using FluentValidation;

namespace ArtistsCatalog.API.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddArtistRequest> _addArtistRequestValidator;

        public ArtistService(
            IArtistRepository repository, 
            IMapper mapper, 
            IValidator<AddArtistRequest> addArtistRequestValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _addArtistRequestValidator = addArtistRequestValidator;
        }
        
        public async Task<ArtistDTO> AddArtist(AddArtistRequest request)
        {
            // ref.: https://docs.fluentvalidation.net/en/latest/start.html#throwing-exceptions
            _addArtistRequestValidator.ValidateAndThrow(request);

            var allArtistsNames = _repository.GetAllArtistNames();

            var registeredMembersPasswordsIds = _repository.GetAllRegisteredMembersPasswordsIds();

            var artist = Artist.Create(request.Name, allArtistsNames);
            foreach (var member in request.Members)
            {
                artist.AddArtistMember(member.PassportId, member.Name, member.Surname, registeredMembersPasswordsIds);
            }

            _repository.Add(artist);

            await _repository.UnitOfWork.SaveChangesAsync();//.SaveEntitiesAsync();

            //Map back result
            return _mapper.Map<ArtistDTO>(artist);
        }
    }
}
