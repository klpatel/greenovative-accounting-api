namespace Greenovative.Accounting.Framework.Data;

public interface IBulkRepository<TEntity, TDbContext> where TEntity : class
{
    Task BulkInsert(IList<TEntity> bulkEntities);
    Task BulkUpdate(IList<TEntity> bulkEntities);
    Task BulkDelete(IList<TEntity> bulkEntities);

}