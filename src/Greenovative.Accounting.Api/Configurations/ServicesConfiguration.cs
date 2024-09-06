using Greenovative.Accounting.Framework.Filters;
using Greenovative.Identity.App.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Greenovative.Accounting.Api.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Greenovative Accounting API", Version = "v1" });

            c.SwaggerDoc("Greenovative.Identity.App", new OpenApiInfo { Title = "Greenovative.Identity.App", Version = "v1" });
            c.SwaggerDoc("Greenovative.Clients.App", new OpenApiInfo { Title = "Greenovative.Clients.App", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
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
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            var identityApiAssemblyXmlFile = $"Greenovative.Identity.App.xml";
            var identityApiAssemblyXmlPath = Path.Combine(AppContext.BaseDirectory, identityApiAssemblyXmlFile);
            c.IncludeXmlComments(identityApiAssemblyXmlPath);

            var clientApiAssemblyXmlFile = $"Greenovative.Clients.App.xml";
            var clientApiAssemblyXmlPath = Path.Combine(AppContext.BaseDirectory, clientApiAssemblyXmlFile);
            c.IncludeXmlComments(clientApiAssemblyXmlPath);

        });

        return services;
    }
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var identityApiAssembly = Assembly.Load("Greenovative.Identity.App");
        var clientApiAssembly = Assembly.Load("Greenovative.Clients.App");

        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //Add automapper
        services.AddAutoMapper(identityApiAssembly,
                               clientApiAssembly);
        //load service from APIs
        services.AddIdentity(configuration);
        services.AddIdentityServices(configuration);
        //services.AddClientServices(configuration);
        services.AddPolicies(configuration);
        // Add mediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServicesConfiguration).GetTypeInfo().Assembly));

        return services;
    }
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        var identityApiAssembly = Assembly.Load("Greenovative.Identity.App");
        var clientApiAssembly = Assembly.Load("Greenovative.Clients.App");


        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        services.AddTransient<HttpEncodeActionFilter>();

        services
            .AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.AddService<HttpEncodeActionFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            })
            .AddApplicationPart(identityApiAssembly);
            //.AddApplicationPart(clientApiAssembly);

        return services;
    }

}
