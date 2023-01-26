using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtistsCatalog.API.Infrastructure.EntityConfigurations
{
    public class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasMany(m => m.Members)
                .WithOne();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(250);
        }
    }
}
