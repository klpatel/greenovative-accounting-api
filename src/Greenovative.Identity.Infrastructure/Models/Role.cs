using Microsoft.AspNetCore.Identity;

namespace Greenovative.Identity.Infrastructure.Models;

public class Role : IdentityRole<Guid>
{
    public Role() : base() { }

    public Role(string roleName) : base(roleName) { }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();
    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
