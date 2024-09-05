using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Greenovative.Accounting.Framework.Data;

public interface IUnitOfWork<TDbContext>
   where TDbContext : DbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default );
}