﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace Greenovative.Identity.Infrastructure.Models;

public partial class AspNetUserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public Guid ClientId { get; set; }

    public int? StoreId { get; set; }

    public virtual AspNetRole Role { get; set; }

    public virtual AspNetUser User { get; set; }
}