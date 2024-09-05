using Microsoft.EntityFrameworkCore;

namespace Greenovative.Accounting.Framework.Data;

public interface IService<TEntity, TDbContext>   where TEntity : class
      where TDbContext : DbContext
{
}
