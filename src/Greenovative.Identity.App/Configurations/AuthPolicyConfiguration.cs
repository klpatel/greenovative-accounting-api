using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Greenovative.Identity.App.Authorisation;
using Greenovative.Identity.Infrastructure.Repositories;
using Greenovative.Accounting.Framework.Authorisation;

namespace Greenovative.Identity.App.Configurations;

public static class AuthPolicyConfiguration
{
    public static IServiceCollection AddPolicies(this IServiceCollection services, IConfiguration configuration)
    {
        var roleService = services.BuildServiceProvider().GetService<IRoleRepository>();

        services.AddAuthorizationCore(x =>
        {
            //Logged in User Policy applies to all roles
            x.AddPolicy(AuthPolicy.UserAccess, policyBuilder =>
            {
                policyBuilder.AddRequirements(new HasRoleRequirement(new string[]
                    { AuthPolicy.UserAccess,AuthPolicy.ClientAdmin,
                        AuthPolicy.ClientAccess, AuthPolicy.SystemAdmin, AuthPolicy.ClientUser }));

            });
            x.AddPolicy(AuthPolicy.ClientAdmin, policyBuilder =>
            {
                policyBuilder.AddRequirements(new HasRoleRequirement(
                    new string[] { AuthPolicy.ClientAdmin, AuthPolicy.SystemAdmin }));
            });
            x.AddPolicy(AuthPolicy.ClientUser, policyBuilder =>
            {
                policyBuilder.AddRequirements(new HasRoleRequirement(
                    new string[] { AuthPolicy.ClientUser, AuthPolicy.ClientAdmin, AuthPolicy.SystemAdmin }));
            });
            x.AddPolicy(AuthPolicy.SystemAdmin, policyBuilder =>
            {
                policyBuilder.AddRequirements(new HasRoleRequirement(
                    new string[] { AuthPolicy.SystemAdmin }));
            });

        });

        services.AddScoped<IAuthorizationHandler, RoleHandler>();
        return services;
    }
}
