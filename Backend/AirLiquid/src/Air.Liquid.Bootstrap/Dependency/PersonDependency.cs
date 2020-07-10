using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Air.Liquide.Bootstrap.Swagger.Person;
using Air.Liquide.Infrastrucutre.Notifiers;
using Air.Liquide.Service.Person;
using Air.Liquide.Data;
using Air.Liquide.Domain.Interface.Person;

namespace Air.Liquide.Bootstrap.Dependency
{
    public static class PersonDependency
    {
        public static IServiceCollection PersonResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //System
            services.AddScoped<Context>();
            services.AddScoped<INotifier, Notifier>();
            // services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, PersonSwaggerConfigureSwaggerOptions>();

            //Customer
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}

