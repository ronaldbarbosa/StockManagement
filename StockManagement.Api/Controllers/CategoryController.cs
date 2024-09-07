using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.Application.Interfaces.Services;

namespace StockManagement.Api.Controllers
{
    [Authorize]    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryAppService appService) : ControllerBase
    {
        private readonly ICategoryAppService _appService = appService;

        [HttpGet]
        public async Task<PagedResponse<CategoryDTO>> GetAllPagedAsync([FromQuery]PagedRequest request)
        {
            return await _appService.GetAllPagedAsync(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<GetCategoryByIdResponse> GetByIdAsync([FromRoute] Guid id)
        {
            var request = new GetCategoryByIdRequest() { Id = id };
            return await _appService.GetByIdAsync(request);
        }

        [HttpPost]
        public async Task<CreateCategoryResponse> CreateAsync([FromBody]CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new CreateCategoryResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }

            return await _appService.CreateAsync(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<UpdateCategoryResponse> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new UpdateCategoryResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }

            request.Id = id;
            return await _appService.UpdateAsync(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseBase> DeleteAsync([FromRoute] Guid id)
        {
            var request = new DeleteCategoryRequest() { Id = id };
            var response = await _appService.DeleteAsync(request);
            return response!;
        }
    }
}
