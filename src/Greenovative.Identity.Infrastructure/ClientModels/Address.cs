﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace Greenovative.Identity.Infrastructure.ClientModels;

public partial class Address : BaseModel
{
    public string Id { get; set; }

    public string Addr1 { get; set; }

    public string Addr2 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string Country { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}