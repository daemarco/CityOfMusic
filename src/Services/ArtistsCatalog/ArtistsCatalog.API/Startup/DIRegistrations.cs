using ArtistsCatalog.API.Application.Requests;
using ArtistsCatalog.API.Application.Services;
using ArtistsCatalog.API.Application.Validations;
using ArtistsCatalog.API.Domain.AggregatesModel.ArtistAggregate;
using ArtistsCatalog.API.Infrastructure.Repositories;
using FluentValidation;

namespace ArtistsCatalog.API.Startup
{
    internal static class DIRegistrations
    {
        internal static void Register(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<IValidator<AddArtistRequest>, AddArtistRequestValidator>();
            //services.AddScoped<IValidator<Artist>, ArtistValidator>();
            //services.AddScoped<IValidator<Member>, MemberValidator>();

            #endregion

            #region Services

            services.AddTransient<IArtistService, ArtistService>();

            #endregion
        }
    }
}
