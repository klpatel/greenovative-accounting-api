using Greenovative.Identity.Infrastructure.ClientModels;
using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IClientRepository : IRepository<Client, ApplicationIdentityDbContext>
{
}
