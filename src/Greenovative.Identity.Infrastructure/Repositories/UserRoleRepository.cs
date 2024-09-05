using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class UserRoleRepository : Repository<AspNetUserRole, IdentityDbContext>, IUserRoleRepository
{
    public UserRoleRepository(IdentityDbContext context) : base(context)
    {
    }

}
