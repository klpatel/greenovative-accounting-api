using Microsoft.AspNetCore.Identity;

namespace Greenovative.Identity.Infrastructure.Models;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    //public string MiddleName { get; set; }
    public string LastName { get; set; }
    public User()
    {
    }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<AspNetUserRole> UserRoles { get; set; } = new List<AspNetUserRole>();

}
