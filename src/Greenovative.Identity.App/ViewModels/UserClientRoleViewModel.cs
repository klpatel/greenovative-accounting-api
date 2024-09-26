#nullable disable

using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.App.ViewModels;

public partial class UserClientRoleViewModel : BaseModel
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public int? StoreId { get; set; }
    public Guid? RoleId { get; set; }
    public bool? IsActive { get; set; }

}
