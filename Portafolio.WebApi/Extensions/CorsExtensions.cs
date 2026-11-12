namespace Portafolio.WebApi.Extensions
{
    /// <summary>
    /// Extensiones para configurar las políticas de CORS de la aplicación.
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// Registra una política de CORS que permite cualquier origen, método y encabezado.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="policy">Nombre de la política de CORS a registrar.</param>
        /// <returns>La misma colección de servicios para permitir el encadenamiento.</returns>
        public static IServiceCollection AddCorsExtensions(this IServiceCollection services, IConfiguration configuration, string policy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policy, builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            });

            return services;
        }
    }
}
