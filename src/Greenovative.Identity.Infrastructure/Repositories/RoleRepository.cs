using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class RoleRepository : Repository<AspNetRole, ApplicationIdentityDbContext>, IRoleRepository
{
    public RoleRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }

}
