using Microsoft.EntityFrameworkCore;
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Requests;
using StockManagement.Core.Entities.Responses;
using StockManagement.Core.Interfaces.Services;
using StockManagement.Data;
using System.Net;

namespace StockManagement.Application.Services
{
    public class CategoryService(DataDbContext dbContext) : ICategoryService
    {
        public async Task<Response<Category?>> CreateAsync(Request<Category> request)
        {
            try
            {
                await dbContext.Categories.AddAsync(request.Data!);
                await dbContext.SaveChangesAsync();
                
                return new Response<Category?>(request.Data, ResponseMessages.Created, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new Response<Category?>(null, ResponseMessages.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Response<Category?>> DeleteAsync(Guid id)
        {
            try
            {
                var category = await dbContext.Categories.FindAsync(id);

                if (category is null)
                {
                    return new Response<Category?>(null, ResponseMessages.NotFound, HttpStatusCode.NotFound);
                }

                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();

                return new Response<Category?>(null, ResponseMessages.Deleted, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return new Response<Category?>(null, ResponseMessages.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(PagedRequest request)
        {
            try
            {
                var query = dbContext.Categories
                    .AsNoTracking()
                    .OrderBy(x => x.Name);

                var categories = await query
                .Skip((request.PageNumber - 1) * request.PageCount)
                .Take(request.PageCount)
                .ToListAsync();

                var response = new PagedResponse<List<Category>?>(categories, ResponseMessages.Ok, HttpStatusCode.OK);
                response.TotalCount = await query.CountAsync();
                response.PageCount = request.PageCount;
                response.CurrentPage = request.PageNumber;

                return response;
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Category>?>(null, ResponseMessages.ServerError, HttpStatusCode.InternalServerError);
            }            
        }

        public async Task<Response<Category?>> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await dbContext.Categories.FindAsync(id);

                if (category is null)
                {
                    return new Response<Category?>(null, ResponseMessages.NotFound, HttpStatusCode.NotFound);
                }

                return new Response<Category?>(category, ResponseMessages.Ok, HttpStatusCode.OK);
            }
            catch (Exception ex) 
            {
                return new Response<Category?>(null, ResponseMessages.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Response<Category?>> UpdateAsync(Guid id, Request<Category> request)
        {
            try
            {
                var category = await dbContext.Categories.FindAsync(id);

                if (category is null) 
                {
                    return new Response<Category?>(null, ResponseMessages.NotFound, HttpStatusCode.NotFound);
                }

                category.Name = request.Data!.Name;
                category.UpdatedAt = DateTime.Now;
                category.UpdatedBy = Guid.Empty;

                dbContext.Categories.Update(category);
                await dbContext.SaveChangesAsync();

                return new Response<Category?>(category, ResponseMessages.Ok, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return new Response<Category?>(null, ResponseMessages.ServerError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
