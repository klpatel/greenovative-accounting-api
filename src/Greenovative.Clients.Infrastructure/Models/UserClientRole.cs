﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace Greenovative.Clients.Infrastructure.Models;

public partial class UserClientRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public Guid? ClientId { get; set; }

    public int? StoreId { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; }

    public DateTimeOffset? CreatedOn { get; set; }

    public string ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedOn { get; set; }
}