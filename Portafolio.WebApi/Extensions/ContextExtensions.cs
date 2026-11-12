using Microsoft.EntityFrameworkCore;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.WebApi.Extensions
{
    /// <summary>
    /// Extensiones para registrar el contexto de base de datos de la aplicación.
    /// </summary>
    public static class ContextExtensions
    {
        /// <summary>
        /// Registra <see cref="PortafolioDbContext"/> usando PostgreSQL y la cadena de conexión configurada.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <returns>La misma colección de servicios para permitir el encadenamiento.</returns>
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
