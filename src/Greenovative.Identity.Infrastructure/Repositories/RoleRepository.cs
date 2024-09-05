using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class RoleRepository : Repository<AspNetRole, IdentityDbContext>, IRoleRepository
{
    public RoleRepository(IdentityDbContext context) : base(context)
    {
    }

}
