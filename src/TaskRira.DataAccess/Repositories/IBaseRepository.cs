using System.Linq.Expressions;
using TaskRira.Core.Common;

namespace TaskRira.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> GetFirstAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAllAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
