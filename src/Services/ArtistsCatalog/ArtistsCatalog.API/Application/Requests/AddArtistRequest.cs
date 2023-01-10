using System.ComponentModel.DataAnnotations;

namespace ArtistsCatalog.API.Application.Requests
{
    public class AddArtistRequest
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Field Length invalid test custom msg")]
        public string Name { get; set; }
        public IEnumerable<MemberItem> Members { get; set; }
    }
}
