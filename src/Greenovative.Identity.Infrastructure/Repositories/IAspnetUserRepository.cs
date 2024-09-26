using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IAspnetUserRepository : IRepository<AspNetUser, ApplicationIdentityDbContext>
{

}
