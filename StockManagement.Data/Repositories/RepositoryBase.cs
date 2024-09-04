using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities.Requests;
using StockManagement.Domain.Entities.Responses;
using StockManagement.Domain.Interfaces.Repositories;

namespace StockManagement.Data.Repositories
{
    public class RepositoryBase<TEntity>(DataDbContext db) : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DataDbContext _db = db;
        protected readonly DbSet<TEntity> _dbSet = db.Set<TEntity>();

        public virtual async Task<TEntity?> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<List<TEntity>?> GetAllAsync()
        {
            var query = _dbSet
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<PagedResponse<TEntity>> GetPagedAsync(PagedRequest request)
        {
            var query = _dbSet
                    .AsNoTracking();

            var entityList = await query
                .Skip((request.PageNumber - 1) * request.PageCount)
                .Take(request.PageCount)
                .ToListAsync();

            var response = new PagedResponse<TEntity>()
            {
                Data = entityList,
                TotalCount = entityList.Count,
                TotalPages = (int)Math.Ceiling((double)entityList.Count / request.PageCount)
            };
            
            return response;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
