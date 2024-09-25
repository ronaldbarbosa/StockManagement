using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces.Services;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlobStorageController(IBlobStorageAppService blobStorageAppService) : ControllerBase
    {
        private readonly IBlobStorageAppService _blobStorageAppService = blobStorageAppService;

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum arquivo foi enviado.");

            var fileName = Path.GetFileName(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                var url = await _blobStorageAppService.UploadFileAsync(stream, fileName, file.ContentType);
                return Ok(new { url });
            }
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadImage(string fileName)
        {
            var stream = await _blobStorageAppService.DownloadFileAsync(fileName);
            if (stream == null)
                return NotFound();

            return File(stream, "application/octet-stream", fileName);
        }
    }
}
