using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using FluentValidation;

namespace ArtistsCatalog.API.Application.Validations
{
    //TODO-Marco - Unit Tests
    //TODO-Marco - check correctness of th namespace
    public class ArtistValidator : AbstractValidator<Artist>
    {
        public ArtistValidator(ILogger<ArtistValidator> logger)
        {
            RuleFor(a => a.Name).NotEmpty();

            RuleFor(a => a.Members).Must(ContainArtistMembers).WithMessage("No Artist members found.");

            RuleForEach(a => a.Members).SetValidator(new MemberValidator());


            logger.LogTrace("Instance Created - {ClassName}", GetType().Name);
        }

        private bool ContainArtistMembers(IEnumerable<Member> members) => members.Any();
    }
}
