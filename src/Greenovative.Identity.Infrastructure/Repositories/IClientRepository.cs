using Greenovative.Identity.Infrastructure.ClientModels;
using Greenovative.Accounting.Framework.Data;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IClientRepository : IRepository<RBAClient, ApplicationIdentityDbContext>
{
}
