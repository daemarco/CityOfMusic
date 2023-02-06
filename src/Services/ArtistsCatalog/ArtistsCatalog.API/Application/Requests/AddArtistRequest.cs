#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ArtistsCatalog.API.Application.Requests
{
    public class AddArtistRequest
    {
        ////[DataMember]
        //[Display(Name = "Artist Name")]
        //[Required(ErrorMessage = "{0} is a Required Field")]
        //[MaxLength(50, ErrorMessage = "Field {0} Length invalid test custom msg")]
        public string Name { get; set; }
        //[DataMember]
        public IEnumerable<MemberItem> Members { get; set; }
    }
}
