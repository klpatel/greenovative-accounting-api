namespace Greenovative.Identity.App.ViewModels;

public partial class UserRoles
{
    public string UserId { get; set; }
    public string RoleId { get; set; }

    public virtual Roles Role { get; set; }
    public virtual UserViewModel User { get; set; }
}
