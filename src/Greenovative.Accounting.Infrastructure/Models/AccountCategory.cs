﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Greenovative.Accounting.Infrastructure.Models;

public partial class AccountCategory
{
    public byte Id { get; set; }

    public byte? AccountTypeId { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual AccountType AccountType { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}