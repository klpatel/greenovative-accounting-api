using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class UserClientRoleRepository : Repository<UserClientRole, IdentityDbContext>, IUserClientRoleRepository
{
    public UserClientRoleRepository(IdentityDbContext context) : base(context)
    {
    }

}
