﻿using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces.Repositories;
using StockManagement.Domain.Interfaces.Services;

namespace StockManagement.Domain.Services
{
    public class CategoryService(IRepositoryBase<Category> repository) : ServiceBase<Category>(repository), ICategoryService
    {
    }
}
