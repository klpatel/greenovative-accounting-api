namespace Greenovative.Identity.App.ViewModels;

public partial class UserClaims
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }

    public virtual UserViewModel User { get; set; }
}
