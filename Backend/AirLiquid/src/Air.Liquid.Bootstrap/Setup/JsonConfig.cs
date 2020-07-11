using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Air.Liquide.Bootstrap.Setup
{
    public static class JsonConfig
    {
        public static IServiceCollection AddCustomJson(this IServiceCollection services)
        {            
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.Formatting = Formatting.None;
                    if (opt.SerializerSettings.ContractResolver != null)
                    {                        
                        var resolver = opt.SerializerSettings.ContractResolver as DefaultContractResolver;
                        resolver.NamingStrategy = null;
                    }
                }
                );
            return services;
        }
    }
}
