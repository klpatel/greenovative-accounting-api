using Microsoft.AspNetCore.Authorization;

namespace Greenovative.Identity.App.Authorisation;

public class HasRoleRequirement : IAuthorizationRequirement
{
    public HasRoleRequirement(string[] roles)
    {
        Roles = roles;
    }

    public string[] Roles { get; }
}
