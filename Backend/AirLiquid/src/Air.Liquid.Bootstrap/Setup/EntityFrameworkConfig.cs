using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Air.Liquide.Data;

namespace Air.Liquide.Bootstrap.Setup
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connectionstring);
            });
            return services;
        }
    }
}
