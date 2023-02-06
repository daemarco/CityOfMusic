using ArtistsCatalog.API.Application.Requests;
using FluentValidation;

namespace ArtistsCatalog.API.Application.Validations
{
    public class AddArtistRequestValidator : AbstractValidator<AddArtistRequest>
    {
        public AddArtistRequestValidator()
        {
            RuleFor(a => a.Name).NotEmpty().Length(0, 250);
        }
    }
}
