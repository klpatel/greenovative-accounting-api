using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.Infrastructure.Models;

namespace Greenovative.Clients.Infrastructure.Repositories;

public class ClientRepository : Repository<Client, ClientDbContext>, IClientRepository
{
    public ClientRepository(ClientDbContext context) : base(context)
    {
    }

    public override void Update(Client rBAClient)
    {
        var context = (ClientDbContext)Context;
        var existingBank = context.Clients.Where(m => m.Id == rBAClient.Id).SingleOrDefault();
        Context.Entry(existingBank).CurrentValues.SetValues(rBAClient);
    }
}
