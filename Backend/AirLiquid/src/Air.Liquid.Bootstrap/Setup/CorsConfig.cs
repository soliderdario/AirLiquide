using Microsoft.Extensions.DependencyInjection;

namespace Air.Liquide.Bootstrap.Setup
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            //.WithOrigins("http://test.airliqued.com.br", "http://www.airliqued.com.br")
                            .SetIsOriginAllowedToAllowWildcardSubdomains());
            });
            return services;
        }
    }
}
