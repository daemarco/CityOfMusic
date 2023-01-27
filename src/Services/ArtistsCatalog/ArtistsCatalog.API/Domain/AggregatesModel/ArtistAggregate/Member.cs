using ArtistsCatalog.API.Domain.Exceptions;
using ArtistsCatalog.API.Domain.SeedWork;

namespace ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate
{
    public class Member : Entity
    {
        public string PassportId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        private Member(string passportId, string name, string surname)
        {
            PassportId = passportId;
            Name = name;
            Surname = surname;
        }

        public static Member Create(string passportId, string name, string surname, string[] registeredMembersPasswordsIds)
        {
            if (string.IsNullOrEmpty(passportId))
                throw new ArtistsCatalogDomainException($"{nameof(passportId)} is mandatory");

            if (string.IsNullOrEmpty(name))
                throw new ArtistsCatalogDomainException($"{nameof(name)} is mandatory");

            if (string.IsNullOrEmpty(surname))
                throw new ArtistsCatalogDomainException($"{nameof(surname)} is mandatory");

            if (registeredMembersPasswordsIds.Contains(passportId, StringComparer.InvariantCultureIgnoreCase))
                throw new ArtistsCatalogDomainException($"Passport Identifier already registered.");

            return new Member(passportId, name, surname);
        }
    }
}
