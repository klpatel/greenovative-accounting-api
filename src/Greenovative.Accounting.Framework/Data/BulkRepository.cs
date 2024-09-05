using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace Greenovative.Accounting.Framework.Data;

public partial class Repository<TEntity, TDbContext> : IBulkRepository<TEntity, TDbContext>
    where TEntity : class
    where TDbContext : DbContext
{
    public async Task  BulkDelete(IList<TEntity> bulkEntities)
    {
        await Context.BulkDeleteAsync<TEntity>(bulkEntities);
    }

    public async Task BulkInsert(IList<TEntity> bulkEntities)
    {
        await Context.BulkInsertAsync<TEntity>(bulkEntities);
    }

    public async Task BulkUpdate(IList<TEntity> bulkEntities)
    {
        await Context.BulkUpdateAsync<TEntity>(bulkEntities);
    }
}