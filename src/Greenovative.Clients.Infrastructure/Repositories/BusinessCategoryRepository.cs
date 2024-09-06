using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.Infrastructure.Models;

namespace Greenovative.Clients.Infrastructure.Repositories;

public class BusinessCategoryRepository : Repository<BusinessCategory, ClientDbContext>, IBusinessCategoryRepository
{
    public BusinessCategoryRepository(ClientDbContext context) : base(context)
    {
    }

}
