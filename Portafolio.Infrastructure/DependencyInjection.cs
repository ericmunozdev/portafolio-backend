using Microsoft.Extensions.DependencyInjection;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Mappings;
using Portafolio.Infrastructure.Repositories;

namespace Portafolio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }
    }
}
