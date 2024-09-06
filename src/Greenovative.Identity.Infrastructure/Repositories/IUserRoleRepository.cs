using Greenovative.Identity.Infrastructure.Models;
using Greenovative.Accounting.Framework.Data;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IUserRoleRepository : IRepository<AspNetUserRole, ApplicationIdentityDbContext>
{
}
