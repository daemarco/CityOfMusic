namespace ArtistsCatalog.API.Domain.Exceptions
{
    /// <summary>
    /// Exception Type for domain exceptions
    /// </summary>
    public class ArtistsCatalogDomainException : Exception
    {
        public ArtistsCatalogDomainException() { }

        public ArtistsCatalogDomainException(string message)
            : base(message)
        { }

        public ArtistsCatalogDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
