﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Greenovative.Identity.Infrastructure.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; }
}