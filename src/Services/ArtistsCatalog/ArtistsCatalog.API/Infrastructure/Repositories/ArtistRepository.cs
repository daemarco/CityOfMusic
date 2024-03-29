﻿using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using ArtistsCatalog.API.Domain.SeedWork;

namespace ArtistsCatalog.API.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ArtistsCatalogContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public ArtistRepository(ArtistsCatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Artist Add(Artist artist)
        {
            //TODO-Marco - check for validations ....
            if (artist.IsTransient())
            {
                return _context.Artists.Add(artist).Entity;
            }

            return artist;
        }

        public string[] GetAllArtistNames()
        {
            return _context.Artists.Select(x => x.Name).ToArray();
        }

        public string[] GetAllRegisteredMembersPasswordsIds()
        {
            return _context.Artists.SelectMany(a => a.Members).Select(m => m.PassportId).ToArray();
        }
    }
}
