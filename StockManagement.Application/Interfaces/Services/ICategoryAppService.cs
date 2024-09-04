using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.Application.Interfaces.Services
{
    public interface ICategoryAppService
    {
        Task<GetCategoryByIdResponse> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<CategoryDTO>> GetAllPagedAsync(PagedRequest request);
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request);
        Task<ResponseBase> DeleteAsync(DeleteCategoryRequest request);
    }
}
