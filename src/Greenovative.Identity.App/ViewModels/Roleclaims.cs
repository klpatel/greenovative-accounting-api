﻿namespace Greenovative.Identity.App.ViewModels;

public partial class RoleClaims
{
    public int Id { get; set; }
    public string RoleId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }

    public virtual Roles Role { get; set; }
}
