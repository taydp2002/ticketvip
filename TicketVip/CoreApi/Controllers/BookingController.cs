using Ecommerce.Application.Handlers.PortfolioCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            //var paging = new PageRequest().GetPageResponse(Request);
            //var result = await _mediator.Send(new GetPortfolioCategoryWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

            //var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
            //return Ok(jsonData);

            var kq = await _mediator.Send(new GetPortfolioCategoryQuery());
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
    }
}
