using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class ClientRepository : Repository<RBAClient, IdentityDbContext>, IClientRepository
{
    public ClientRepository(IdentityDbContext context) : base(context)
    {
    }

}
