using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Mvc.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UploadController : Controller
	{
		private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
		public UploadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
		{
			_environment = environment;
		}
		
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(List<IFormFile> file)
        {
            var uploads = file;
            //if (file.Length > 0)
            //{
            //    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
            //    {
            //        await file.CopyToAsync(fileStream);
            //    }
            //}
            return Ok("test");
        }
    }
}
