using Ecommerce.Application.Handlers.BlogCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogCategoryController(IMediator mediator)
        {
            //_keyAccessor = keyAccessor;
            _mediator = mediator;
        }
        [HttpGet]
       // [HttpGet(Name = "GetBlogCategoryAll")]
      //  [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var kq = await _mediator.Send(new GetBlogCategoryQuery());
            return Ok(kq.ToArray());


        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            string para=slug;
            var kq = await _mediator.Send(new GetBlogCategoryQuery());
            return Ok(kq.ToArray());


        }

        [HttpGet("error")]
        public async Task<IActionResult> Error(string slug)
        {
            string para = slug;
            var kq = await _mediator.Send(new GetBlogCategoryQuery());
            return Ok(kq.ToArray());


        }

    }
}
