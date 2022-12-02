using ArtistsCatalog.API.Application.Services;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using ArtistsCatalog.API.Infrastructure.Repositories;

namespace ArtistsCatalog.API.Startup
{
    internal static class DIRegistrations
    {
        internal static void Register(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<IArtistRepository, ArtistRepository>();

            #endregion

            #region Services

            services.AddTransient<IArtistService, ArtistService>();

            #endregion
        }
    }
}
