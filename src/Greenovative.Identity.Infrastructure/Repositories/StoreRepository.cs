using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.Infrastructure.Repositories;

public interface IStoreRepository : IRepository<Store, IdentityDbContext>
{
}
public class StoreRepository : Repository<Store, IdentityDbContext>, IStoreRepository
{
    public StoreRepository(IdentityDbContext context) : base(context)
    {
    }
}

