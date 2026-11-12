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
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ICategorySkillRepository, CategorySkillRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IAdditionalRepository, AdditionalRepository>();

            return services;
        }
    }
}
