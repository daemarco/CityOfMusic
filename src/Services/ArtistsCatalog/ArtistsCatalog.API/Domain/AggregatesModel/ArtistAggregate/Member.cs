using ArtistsCatalog.API.Domain.SeedWork;

namespace ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Member(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
