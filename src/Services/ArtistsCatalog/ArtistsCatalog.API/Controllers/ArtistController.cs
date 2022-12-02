using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Responses;
using ArtistsCatalog.API.Application.Services;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using Microsoft.AspNetCore.Mvc;

namespace ArtistsCatalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistService _service;

        public ArtistController(ILogger<ArtistController> logger, IArtistService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return new List<Artist>
            {
                new Artist("Skyye"),
                new Artist("Aerosmith"),//, new List<Member>{ new Member("Steven", "Tyler"), new Member("Joe", "Perry") }),
                new Artist("Metallica")//, new List<Member>{ new Member("Kirk", "Hammet"), new Member("James", "Hetfield") })
            };
        }

        //TODO-Marco - Enrich OpenAPI
        [HttpPost("[action]")]
        public async Task<ActionResult<ArtistDTO>> Add([FromBody] AddArtistRequest request)
        { 
            return await _service.AddArtistRequest(request);
        }
    }
}