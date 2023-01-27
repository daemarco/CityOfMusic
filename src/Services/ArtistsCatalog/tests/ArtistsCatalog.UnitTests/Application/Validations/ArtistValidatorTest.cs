using ArtistsCatalog.API.Application.Validations;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Logging;
using Moq;

namespace ArtistsCatalog.UnitTests.Application.Validations
{
    public class ArtistValidatorTest
    {
        private readonly Mock<ILogger<ArtistValidator>> _loggerMock;

        private readonly IValidator<Artist> _validator;

        private readonly string[] _allArtistNames;

        public ArtistValidatorTest()
        {
            _loggerMock = new Mock<ILogger<ArtistValidator>>();

            _validator = new ArtistValidator(_loggerMock.Object);

            _allArtistNames = new string[] { "Rolling Stones", "Deep Purple", "Metallica" };
        }

        ////[Fact]
        ////public void Should_have_error_when_Name_Is_Empty() 
        ////{
        ////    // Arrange
        ////    var artist = Artist.Create(string.Empty, _allArtistNames);
        ////    artist.AddArtistMember("Jimi", "Hendrix");

        ////    // Act
        ////    var actual = _validator.TestValidate(artist);

        ////    // Assert
        ////    actual.ShouldHaveValidationErrorFor(a => a.Name).WithErrorCode("NotEmptyValidator").Only();
        ////}

        ////[Fact]
        ////public void Should_have_error_when_ArtistMember_Is_Not_specified()
        ////{
        ////    // Arrange
        ////    var artist = Artist.Create("Aerosmith", _allArtistNames);

        ////    // Act
        ////    var actual = _validator.TestValidate(artist);

        ////    // Assert
        ////    actual.ShouldHaveValidationErrorFor(a => a.Members).WithErrorMessage("No Artist members found.").Only();
        ////}

        ////[Fact]
        ////public void Should_have_error_when_Member_Name_Is_Empty()
        ////{
        ////    // Arrange
        ////    var artist = Artist.Create("Aerosmith", _allArtistNames);
        ////    artist.AddArtistMember(string.Empty, "Hendrix");

        ////    // Act
        ////    var actual = _validator.TestValidate(artist);

        ////    // Assert
        ////    actual.ShouldHaveValidationErrorFor("Members[0].Name").WithErrorCode("NotEmptyValidator").Only();
        ////}

        ////[Fact]
        ////public void Should_have_error_when_Member_Surname_Is_Empty()
        ////{
        ////    // Arrange
        ////    var artist = Artist.Create("Aerosmith", _allArtistNames);
        ////    artist.AddArtistMember("Jimi", string.Empty);

        ////    // Act
        ////    var actual = _validator.TestValidate(artist);

        ////    // Assert
        ////    actual.ShouldHaveValidationErrorFor("Members[0].Surname").WithErrorCode("NotEmptyValidator").Only();
        ////}

        ////[Fact]
        ////public void Should_Not_have_error_when_Name_and_Members_are_specified()
        ////{
        ////    // Arrange
        ////    var artist = Artist.Create("Aerosmith", _allArtistNames);
        ////    artist.AddArtistMember("Jimi", "Hendrix");

        ////    // Act
        ////    var actual = _validator.TestValidate(artist);

        ////    // Assert
        ////    actual.ShouldNotHaveAnyValidationErrors();
        ////}

        //[Fact]
        //public void Should_have_error_when_Artist_name_exists_already()
        //{
        //    // Arrange
        //    var artist = Artist.Create("Aerosmith", _allArtistNames);
        //    artist.AddArtistMember("Steven", "Tyler");

        //    // Act
        //    var actual = _validator.Validate(artist);//TestValidate(artist);

        //    // Assert
        //    //actual.ShouldHaveAnyValidationError();
        //    Assert.False(actual.IsValid);
        //}
    }
}
