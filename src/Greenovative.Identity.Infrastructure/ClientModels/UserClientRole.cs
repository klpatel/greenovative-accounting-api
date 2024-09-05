#nullable disable

namespace Greenovative.Identity.Infrastructure.ClientModels;

public partial class UserClientRole : BaseModel
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public Guid ClientId { get; set; }
    public int? StoreId { get; set; }
    public int? RoleId { get; set; }
    public bool? IsActive { get; set; }

}
