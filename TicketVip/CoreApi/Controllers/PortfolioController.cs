using Ecommerce.Application.Handlers.Categories.Queries;
using Ecommerce.Application.Handlers.Colors.Queries;
using Ecommerce.Application.Handlers.Portfolio.Queries;
using Ecommerce.Application.Handlers.PortfolioCategory.Queries;
using Ecommerce.Application.Handlers.Sizes.Queries;
using Ecommerce.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            //_keyAccessor = keyAccessor;
            _mediator = mediator;
        }
        [HttpGet(Name = "PortfolioAll")]
        public async Task<IActionResult> GetAll()
        {
            //var paging = new PageRequest().GetPageResponse(Request);
            //var result = await _mediator.Send(new GetPortfolioCategoryWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

            //var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
            //return Ok(jsonData);

            var kq = await _mediator.Send(new GetPortfolioQuery());
            //  ViewBag.HeaderSlider = headerSlider;
            return Ok(kq.ToArray());

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _mediator.Send(new GetPortfolioByIdQuery { Id = id });
        
            if (response == null) return NotFound();

            return Ok(response);
        }
        [HttpGet("GetDetailBy/{slug}")]
        public async Task<IActionResult> DetailBySlug(string slug)
        {
            var response = await _mediator.Send(new GetPortfolioBySlugQuery { Slug = slug });


            if (response == null) return NotFound();


            return Ok(response);
        }

    }
}
