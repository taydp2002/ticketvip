using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "HomeGetAll")]
        public async Task<IActionResult> GetAll()
        {

            return Ok("ok");
        }
    }
}
