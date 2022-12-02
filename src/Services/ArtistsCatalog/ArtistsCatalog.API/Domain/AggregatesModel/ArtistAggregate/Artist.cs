using ArtistsCatalog.API.Domain.SeedWork;
using System.Diagnostics.CodeAnalysis;

namespace ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate
{
    public class Artist : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public bool IsBand => Members.Any();

        public List<Member> Members { get; private set; }

        public Artist(string name)
        {
            Members = new List<Member>();
            Name = name;            
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
