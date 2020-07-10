using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Air.Liquide.Bootstrap.Swagger.Person
{
    public static class PersonSwaggerApiVersionConfig
    {
        public static IServiceCollection PersonApiVersionSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insert the token JWT this way: Bearer {your token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
        public static IApplicationBuilder PersonUseApiVersionSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
               options =>
               {
                   foreach (var description in provider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                   }
               });
            return app;
        }
    }
    public class PersonSwaggerConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {

        readonly IApiVersionDescriptionProvider provider;

        public PersonSwaggerConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Air Liquid Person API - Desenvolver Backend",
                Version = description.ApiVersion.ToString(),
                Description = "This API contains all the features to be used in person module",
                Contact = new OpenApiContact() { Name = "Dario Martins Bueno Leandro", Email = "soliderdario@hotmail.com" },
                TermsOfService = new Uri("https://www.airliquide.com/"),
                License = new OpenApiLicense() { Name = "Notorious", Url = new Uri("https://www.airliquide.com/") }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This version is Deprecated!";
            }

            return info;
        }
    }
}