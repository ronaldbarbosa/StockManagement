using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces.Repositories;

namespace StockManagement.Data.Repositories
{
    public class SystemResourceRepository(DataDbContext db) : RepositoryBase<SystemResource>(db), ISystemResourceRepository
    {
        public override async Task<List<SystemResource>?> GetAllAsync()
        {
            var query = _dbSet
                .Where(x => x.ParentId == null)
                .Include(x => x.Children)
                .AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
