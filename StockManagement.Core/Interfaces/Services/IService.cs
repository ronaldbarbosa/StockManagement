using StockManagement.Core.Entities.Requests;
using StockManagement.Core.Entities.Responses;

namespace StockManagement.Core.Interfaces.Services
{
    public interface IService<TEntity>
    {
        Task<Response<TEntity?>> GetByIdAsync(Guid id);
        Task<PagedResponse<List<TEntity>?>> GetAllAsync(PagedRequest request);
        Task<Response<TEntity?>> CreateAsync(Request<TEntity> request);
        Task<Response<TEntity?>> UpdateAsync(Guid id, Request<TEntity> request);
        Task<Response<TEntity?>> DeleteAsync(Guid id);
    }
}
