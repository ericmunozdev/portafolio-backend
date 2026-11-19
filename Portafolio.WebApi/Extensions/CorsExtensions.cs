namespace Portafolio.WebApi.Extensions
{
    /// <summary>
    /// Extensiones para configurar las políticas de CORS de la aplicación.
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// Registra una política de CORS con los orígenes configurados en <c>Cors:AllowedOrigins</c>.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="policy">Nombre de la política de CORS a registrar.</param>
        /// <returns>La misma colección de servicios para permitir el encadenamiento.</returns>
        /// <remarks>
        /// Si no hay orígenes configurados, la política no permite ninguno. El valor
        /// <c>*</c> habilita cualquier origen.
        /// </remarks>
        public static IServiceCollection AddCorsExtensions(this IServiceCollection services, IConfiguration configuration, string policy)
        {
            var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

            services.AddCors(options =>
            {
                options.AddPolicy(policy, builder =>
                {
                    if (allowedOrigins.Contains("*", StringComparer.Ordinal))
                    {
                        builder.AllowAnyOrigin();
                    }
                    else
                    {
                        builder.WithOrigins(allowedOrigins);
                    }

                    builder.AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
