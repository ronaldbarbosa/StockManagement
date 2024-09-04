using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces.Repositories;

namespace StockManagement.Data.Repositories
{
    public class CategoryRepository(DataDbContext db) : RepositoryBase<Category>(db), ICategoryRepository
    {
    }
}
