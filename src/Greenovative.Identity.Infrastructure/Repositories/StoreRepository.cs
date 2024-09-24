using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IStoreRepository : IRepository<Store, ApplicationIdentityDbContext>
{
}
public class StoreRepository : Repository<Store, ApplicationIdentityDbContext>, IStoreRepository
{
    public StoreRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }
}

