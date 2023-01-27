using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Responses;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using AutoMapper;
using FluentValidation;

namespace ArtistsCatalog.API.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Artist> _validator;

        public ArtistService(
            IArtistRepository repository, 
            IMapper mapper, 
            IValidator<Artist> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        
        public async Task<ArtistDTO> AddArtist(AddArtistRequest request)
        {
            var allArtistsNames = _repository.GetAllArtistNames();

            var registeredMembersPasswordsIds = _repository.GetAllRegisteredMembersPasswordsIds();

            var artist = Artist.Create(request.Name, allArtistsNames);
            foreach (var member in request.Members)
            {
                artist.AddArtistMember(member.PassportId, member.Name, member.Surname, registeredMembersPasswordsIds);
            }

            _repository.Add(artist);

            // ref.: https://docs.fluentvalidation.net/en/latest/start.html#throwing-exceptions
            //TODO-Marco - "think" still I need to do it "here"? I start thinking FluentValidation would need to be applied to the command/request obj instead....
            _validator.ValidateAndThrow(artist);

            await _repository.UnitOfWork.SaveChangesAsync();//.SaveEntitiesAsync();

            //Map back result
            return _mapper.Map<ArtistDTO>(artist);
        }
    }
}
