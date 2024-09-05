#nullable disable

using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.App.ViewModels;

public partial class UserClientRoleViewModel : BaseModel
{
    public int? UserId { get; set; }
    public Guid ClientId { get; set; }
    public int? StoreId { get; set; }
    public int? RoleId { get; set; }
    public bool? IsActive { get; set; }

}
