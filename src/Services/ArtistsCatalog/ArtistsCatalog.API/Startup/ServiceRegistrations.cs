using ArtistsCatalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ArtistsCatalog.API.Startup
{
    internal static class ServiceRegistrations
    {
        internal static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArtistsCatalogContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("CatalogDatabase")));

            services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}
