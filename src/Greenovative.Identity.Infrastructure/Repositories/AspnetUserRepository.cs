using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class AspnetUserRepository : Repository<AspNetUser, ApplicationIdentityDbContext>, IAspnetUserRepository
{
    public AspnetUserRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }
}
