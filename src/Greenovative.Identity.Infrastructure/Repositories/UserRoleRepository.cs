using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class UserRoleRepository : Repository<AspNetUserRole, ApplicationIdentityDbContext>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }

}
