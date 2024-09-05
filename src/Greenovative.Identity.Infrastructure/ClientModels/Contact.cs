#nullable disable

namespace Greenovative.Identity.Infrastructure.ClientModels;

public partial class Contact
{
    public Contact()
    {
        Clients = new HashSet<RBAClient>();
    }

    public int Id { get; set; }
    public string HomePhone { get; set; }
    public string OfficePhone { get; set; }
    public string CellPhone { get; set; }
    public string Email1 { get; set; }
    public string Email2 { get; set; }

    public virtual ICollection<RBAClient> Clients { get; set; }
}
