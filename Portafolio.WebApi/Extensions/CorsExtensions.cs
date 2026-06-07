namespace Portafolio.WebApi.Extensions
{
    public static class CorsExtensions
    {
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
