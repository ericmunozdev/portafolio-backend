using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Portafolio.WebApi.Extensions
{
    /// <summary>
    /// Extensiones para configurar la documentación Swagger de la API.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Registra Swagger con la información del documento, los tipos personalizados y la seguridad por token.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <returns>La misma colección de servicios para permitir el encadenamiento.</returns>
        public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(c =>
            {
                var swaggerConfigV1 = configuration.GetSection("SwaggerConfigV1");

                c.SwaggerDoc(swaggerConfigV1["Name"], new OpenApiInfo
                {
                    Version = swaggerConfigV1["Version"],
                    Title = swaggerConfigV1["Title"],
                    Description = swaggerConfigV1["Description"]
                });

                c.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });

                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación JWT (Bearer)",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
