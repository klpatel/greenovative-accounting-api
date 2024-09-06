using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class ClientRepository : Repository<RBAClient, ApplicationIdentityDbContext>, IClientRepository
{
    public ClientRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }

}
