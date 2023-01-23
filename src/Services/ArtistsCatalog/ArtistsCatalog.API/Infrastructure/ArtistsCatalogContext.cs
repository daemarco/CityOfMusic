using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using ArtistsCatalog.API.Domain.SeedWork;
using ArtistsCatalog.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ArtistsCatalog.API.Infrastructure
{
    public class ArtistsCatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Artist> Artists { get; set; }

        public ArtistsCatalogContext()
        {
        }

        public ArtistsCatalogContext(DbContextOptions<ArtistsCatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            //// Dispatch Domain Events collection. 
            //// Choices:
            //// A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            //// side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            //// B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            //// You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //await _mediator.DispatchDomainEventsAsync(this);

            //// After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            //// performed through the DbContext will be committed
            //var result = await base.SaveChangesAsync(cancellationToken);

            //return true;

            throw new NotImplementedException("TODO-Marco");
        }
    }
}
