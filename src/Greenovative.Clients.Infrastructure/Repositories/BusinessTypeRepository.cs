using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.Infrastructure;
using Greenovative.Clients.Infrastructure.Models;
using Greenovative.Clients.Infrastructure.Repositories;

namespace LotoMate.Client.Infrastructure.Repositories
{
    public class BusinessTypeRepository : Repository<BusinessType, ClientDbContext>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(ClientDbContext context) : base(context)
        {
        }

    }
}
