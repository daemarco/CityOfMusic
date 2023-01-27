using ArtistsCatalog.API.Domain.Exceptions;
using ArtistsCatalog.API.Domain.SeedWork;

namespace ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate
{
    public class Artist : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public bool IsBand => Members.Any();

        public List<Member> Members { get; private set; }

        private Artist(string name)
        {
            Members = new List<Member>();
            Name = name;            
        }

        public static Artist Create(string name, string[] allArtistNames)
        {
            if (allArtistNames.Contains(name))
                throw new ArtistsCatalogDomainException("Artist name in use already.");

            return new Artist(name);
        }

        /// <summary>
        /// DDD Pattern comment. This Artist aggregate method should be the only way to add members to the Order,
        /// so any behaviour and validations are controlled by the AggregateRoot in order to maintain consistency
        /// between the whole Aggregate
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void AddArtistMember(string name, string surname)
        {
            Members.Add(new Member(name, surname));
        }
    }
}
