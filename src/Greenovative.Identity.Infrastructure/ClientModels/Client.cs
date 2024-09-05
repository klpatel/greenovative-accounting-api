using Greenovative.Identity.Infrastructure.Models;

#nullable disable

namespace Greenovative.Identity.Infrastructure.ClientModels;

public partial class RBAClient : BaseModel
{
    public RBAClient()
    {
        AspNetUserRoles = new HashSet<AspNetUserRole>();
        Stores = new HashSet<Store>();
    }
    public Guid Id { get; set; }
    public string ClientFname { get; set; }
    public string ClientMname { get; set; }
    public string ClientLname { get; set; }
    public int? AddressId { get; set; }
    public int? ContactId { get; set; }
    public string IsActive { get; set; }

    public virtual Address Address { get; set; }
    public virtual Contact Contact { get; set; }
    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
}
