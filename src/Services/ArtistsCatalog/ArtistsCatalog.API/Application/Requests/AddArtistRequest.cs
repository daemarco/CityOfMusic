namespace ArtistsCatalog.API.Application.Requests
{
    public class AddArtistRequest
    {
        public string Name { get; set; }
        public IEnumerable<MemberItem> Members { get; set; }
    }
}
