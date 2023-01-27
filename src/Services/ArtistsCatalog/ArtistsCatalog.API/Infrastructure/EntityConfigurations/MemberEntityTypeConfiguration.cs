using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtistsCatalog.API.Infrastructure.EntityConfigurations
{
    public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.PassportId).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Surname).IsRequired().HasMaxLength(50);
        }
    }
}
