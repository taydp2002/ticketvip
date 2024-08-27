using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Mvc.Controllers
{
    [AllowAnonymous]
    public class UploadController : Controller
	{
		private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
		public UploadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
		{
			_environment = environment;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = @"C:\Temp\";
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
