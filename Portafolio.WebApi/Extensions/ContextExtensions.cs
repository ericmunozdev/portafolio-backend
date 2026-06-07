using Microsoft.EntityFrameworkCore;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.WebApi.Extensions
{
    public static class ContextExtensions
    {
        public static IServiceCollection AddDbContextExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddDbContext<PortafolioDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
