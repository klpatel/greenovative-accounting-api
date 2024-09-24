using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class ClientRepository : Repository<Client, ApplicationIdentityDbContext>, IClientRepository
{
    public ClientRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }

}
