using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using AutoMapper;
using Air.Liquide.Bootstrap.AutoMapper;
using Air.Liquide.Bootstrap.Dependency;
using Air.Liquide.Bootstrap.Setup;
using Air.Liquide.Bootstrap.Swagger.Person;

namespace Air.Liquede.Person
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();            

            //Auto Mapper Configuration 
            services.AddAutoMapper(typeof(PersonAutoMapper));

            //Dependency Injection Configuration
            services.PersonResolveDependencies(this.Configuration);

            //Entity Framework Configuration
            services.AddDbContextConfiguration(Configuration.GetConnectionString("DefaultConnection"));            

            //Api Versioning  Configuration
            services.AddApiVersioningCustom();

            //Swagger Obs. Declare your namespace before {using Good.Doctor.Configuration}            
            services.PersonApiVersionSwagger();
                        
            //Cors Configuration
            services.AddCorsConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.PersonUseApiVersionSwaggerConfiguration(provider);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
