using StockManagement.Domain.Entities.Requests;
using StockManagement.Domain.Entities.Responses;

namespace StockManagement.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<List<TEntity>?> GetAllAsync();
        Task<PagedResponse<TEntity>> GetPagedAsync(PagedRequest request);
        Task<TEntity?> CreateAsync(TEntity request);
        Task UpdateAsync(Guid id, TEntity request);
        Task DeleteAsync(Guid id);
    }
}
