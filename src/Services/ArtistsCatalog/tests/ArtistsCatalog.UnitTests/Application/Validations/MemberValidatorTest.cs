using ArtistsCatalog.API.Application.Validations;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using FluentValidation.Results;
using FluentValidation.TestHelper;

namespace ArtistsCatalog.UnitTests.Application.Validations
{
    // check https://docs.fluentvalidation.net/en/latest/testing.html
    public class MemberValidatorTest
    {
        private readonly IValidator<Member> _validator;

        public MemberValidatorTest()
        {
            _validator = new MemberValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_And_Surname_Are_Empty() 
        {
            // Arrange
            var member = new Member(string.Empty, string.Empty);

            // Act
            var actual = _validator.TestValidate(member);

            // Assert
            actual.ShouldHaveValidationErrorFor(m => m.Name).WithErrorCode("NotEmptyValidator");

            actual.ShouldHaveValidationErrorFor(m => m.Surname).WithErrorCode("NotEmptyValidator");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            // Arrange
            var member = new Member(string.Empty, "not empty");

            // Act
            var actual = _validator.TestValidate(member);

            // Assert
            actual.ShouldHaveValidationErrorFor(m => m.Name).WithErrorCode("NotEmptyValidator").Only();
        }

        [Fact]
        public void Should_Have_Error_When_Surname_Is_Empty()
        {
            // Arrange
            var member = new Member("not empty", string.Empty);

            // Act
            var actual = _validator.TestValidate(member);

            // Assert
            actual.ShouldHaveValidationErrorFor(m => m.Surname).WithErrorCode("NotEmptyValidator").Only();
        }

        [Fact]
        public void Should_Not_Have_Error_When_NameAndSurname_Are_Specified()
        {
            // Arrange
            var member = new Member("not empty", "not empty");

            // Act
            var actual = _validator.TestValidate(member);

            // Assert
            actual.ShouldNotHaveAnyValidationErrors();
        }
    }
}
