using Microsoft.AspNetCore.Identity;

namespace Greenovative.Identity.Infrastructure.Models;

public class Role : IdentityRole<Guid>
{
    public Role() : base() { }

    public Role(string roleName) : base(roleName) { }


}
