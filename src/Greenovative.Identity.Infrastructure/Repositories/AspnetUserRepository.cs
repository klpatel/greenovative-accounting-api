using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class AspnetUserRepository : Repository<AspNetUser, IdentityDbContext>, IAspnetUserRepository
{
    public AspnetUserRepository(IdentityDbContext context) : base(context)
    {
    }
}
