using StockManagement.Domain.Entities.Requests;
using StockManagement.Domain.Entities.Responses;
using StockManagement.Domain.Interfaces.Repositories;
using StockManagement.Domain.Interfaces.Services;

namespace StockManagement.Domain.Services
{
    public class ServiceBase<TEntity>(IRepositoryBase<TEntity> repository) : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository = repository;

        public virtual async Task<TEntity?> CreateAsync(TEntity request)
        {
            return await _repository.CreateAsync(request);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }

        public virtual async Task<List<TEntity>?> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<PagedResponse<TEntity>> GetPagedAsync(PagedRequest request)
        {
            return await _repository.GetPagedAsync(request);
        }

        public virtual async Task UpdateAsync(Guid id, TEntity request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                entity = request;
                await _repository.UpdateAsync(entity);
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
