using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using FluentValidation;

namespace ArtistsCatalog.API.Application.Validations
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator(/*ILogger<MemberValidator> logger*/)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);

            //logger.LogTrace("Instance Created - {ClassName}", GetType().Name);
        }
    }
}
