using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfoAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _extensionContentTypeProvider;

        public FileController(FileExtensionContentTypeProvider extensionContentTypeProvider)
        {
            _extensionContentTypeProvider = extensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(extensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(int fileId)
        {
            var filePath = "meadows avalanche.pdf";

            if (!System.IO.File.Exists(filePath)) { return NoContent(); }

            if(!_extensionContentTypeProvider.TryGetContentType( filePath,out var contentType))
            {
                contentType = "application/octet-stream";
            }
            
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType,Path.GetFileName(filePath));
        }
    }
}
