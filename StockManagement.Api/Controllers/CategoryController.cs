using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs.Request;
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Requests;
using StockManagement.Core.Entities.Responses;
using StockManagement.Core.Interfaces.Services;
using System.Net;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        private readonly ICategoryService _service = service;

        [HttpGet]
        public async Task<PagedResponse<List<Category>?>> GetPaged([FromQuery]PagedRequest request) 
        {
            return await _service.GetAllAsync(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Response<Category?>> GetById([FromRoute] Guid id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<Category?>> Create([FromBody] Request<CreateCategoryRequest> request)
        {
            if (request.Data is null)
            {
                return new Response<Category?>(null, ResponseMessages.RequestError, HttpStatusCode.BadRequest);
            }
            var category = new Category(request.Data.Name, Guid.Empty);
            var response = await _service.CreateAsync(new Request<Category>() { Data = category });

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Response<Category?>> Update([FromRoute] Guid id, [FromBody] Request<UpdateCategoryRequest> request)
        {
            if (request.Data is null)
            {
                return new Response<Category?>(null, ResponseMessages.RequestError, HttpStatusCode.BadRequest);
            }

            var category = new Category(request.Data.Name, Guid.Empty);
            var response = await _service.UpdateAsync(id, new Request<Category>() { Data = category });

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response<Category?>> Delete([FromRoute] Guid id)
        {
            var response = await _service.DeleteAsync(id);
            return response;
        }
    }
}
