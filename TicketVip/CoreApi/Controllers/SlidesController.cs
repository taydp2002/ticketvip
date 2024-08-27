using Ecommerce.Application.Dto;
using Ecommerce.Application.Handlers.RenderItems.Queries;
using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
   // [Route("[controller]")]
   // [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class SlidesController : ControllerBase
    {
     //  private readonly IKeyAccessor _keyAccessor;
        private readonly IMediator _mediator;

        public SlidesController(IMediator mediator)
        {
            //_keyAccessor = keyAccessor;
            _mediator = mediator;
        }
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var headerSlider = await _mediator.Send(new GetHeaderSliderQuery());
        //    ViewBag.HeaderSlider = headerSlider;
        //    return View();
        //}

        [HttpGet(Name = "Slides")]
        public async Task<IEnumerable<HeaderSliderDto>> Get()
        {
            var headerSlider = await _mediator.Send(new GetHeaderSliderQuery());
            //  ViewBag.HeaderSlider = headerSlider;
            return headerSlider.ToArray();

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
