using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.Infrastructure.Models;

namespace Greenovative.Clients.Infrastructure.Repositories;

public class StoreRepository : Repository<Store, ClientDbContext>, IStoreRepository
{
    public StoreRepository(ClientDbContext context) : base(context)
    {
    }

    public override void Update(Store store)
    {
        var context = (ClientDbContext)Context;
        var existingBank = context.Stores.Where(m => m.Id == store.Id).SingleOrDefault();
        Context.Entry(existingBank).CurrentValues.SetValues(store);
    }
}
