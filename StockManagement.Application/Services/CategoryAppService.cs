using System.Net;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Application.DTOs.Response;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs;
using StockManagement.Domain.Interfaces.Services;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Services
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category(request.Name, request.UserId);
                var response = await categoryService.CreateAsync(category);
                
                if (response is not null)
                {
                    return new CreateCategoryResponse()
                    {
                        Category = (CategoryDTO)response,
                        StatusCode = HttpStatusCode.Created,
                    };
                }

                return new CreateCategoryResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<ResponseBase> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(request.Id);

                if (category is null)
                {
                    return new ResponseBase()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                    };
                }

                await categoryService.DeleteAsync(category.Id);

                return new ResponseBase()
                {
                    StatusCode = HttpStatusCode.NotFound,
                }; ;
            }
            catch (Exception ex)
            {
                return new ResponseBase() 
                { 
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<PagedResponse<CategoryDTO>> GetAllPagedAsync(PagedRequest request)
        {
            try
            {
                var categories = await categoryService.GetPagedAsync(new Domain.Entities.Requests.PagedRequest()
                {
                    PageCount = request.PageCount,
                    PageNumber = request.PageNumber,
                });

                var categoriesDTO = new List<CategoryDTO>();

                if (categories is not null)
                {
                    foreach (var category in categories.Data)
                    {
                        categoriesDTO.Add((CategoryDTO)category);
                    }

                    var response = new PagedResponse<CategoryDTO>()
                    {
                        Data = categoriesDTO,
                        CurrentPage = request.PageNumber,
                        PageCount = request.PageCount,
                        TotalPages = categories.TotalPages
                    };
                    response.TotalCount = categories.TotalCount;
                    response.PageCount = request.PageCount;
                    response.CurrentPage = request.PageNumber;

                    return response;
                }
                else
                {
                    return new PagedResponse<CategoryDTO> 
                    { 
                        StatusCode = HttpStatusCode.NotFound
                    };
                }                    
            }
            catch (Exception ex)
            {
                return new PagedResponse<CategoryDTO>
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }            
        }

        public async Task<GetCategoryByIdResponse> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(request.Id);

                if (category is null)
                {
                    return new GetCategoryByIdResponse()
                    {
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                return new GetCategoryByIdResponse()
                {
                    Category = (CategoryDTO)category,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex) 
            {
                return new GetCategoryByIdResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(request.Id);

                if (category is null) 
                {
                    return new UpdateCategoryResponse()
                    {
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                category.Name = request.Name;
                category.UpdatedAt = DateTime.Now;
                category.UpdatedBy = Guid.Empty;

                await categoryService.UpdateAsync(category.Id, category);

                return new UpdateCategoryResponse()
                {
                    Category = (CategoryDTO)category,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
