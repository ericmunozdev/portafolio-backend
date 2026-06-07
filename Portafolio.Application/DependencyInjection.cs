using Microsoft.Extensions.DependencyInjection;
using Portafolio.Application.Services;

namespace Portafolio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICurriculumService, CurriculumService>();

            return services;
        }
    }
}
