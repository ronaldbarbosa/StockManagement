using StockManagement.Domain.Entities.Requests;
using StockManagement.Domain.Entities.Responses;

namespace StockManagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<List<TEntity>?> GetAllAsync();
        Task<PagedResponse<TEntity>> GetPagedAsync(PagedRequest request);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
