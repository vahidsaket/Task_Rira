using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskRira.Core.Common;
using TaskRira.Core.Exceptions;
using TaskRira.DataAccess.Persistence;

namespace TaskRira.DataAccess.Repositories.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            TEntity removedEntity = _dbSet.Remove(entity).Entity;
            await _context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            async Task<IList<TEntity>> getAllAsync()
            {
                var query = _dbSet.AsTracking();
                query = predicate != null ? query.Where(predicate) : query;

                return await query.ToListAsync();
            }

            return await getAllAsync();
        }

        public async Task<IList<TEntity>> GetAllAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            async Task<IList<TEntity>> getAllAsync()
            {
                var query = _dbSet.AsNoTracking();
                query = predicate != null ? query.Where(predicate) : query;

                return await query.ToListAsync();
            }

            return await getAllAsync();
        }

        public async Task<TEntity> GetFirstAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();

            if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = await _dbSet.Where(predicate).FirstOrDefaultAsync();

            if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }

}
