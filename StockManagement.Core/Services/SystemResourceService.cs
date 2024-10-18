using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces.Repositories;
using StockManagement.Domain.Interfaces.Services;

namespace StockManagement.Domain.Services
{
    public class SystemResourceService(ISystemResourceRepository repository) : ServiceBase<SystemResource>(repository), ISystemResourceService
    {
    }
}
