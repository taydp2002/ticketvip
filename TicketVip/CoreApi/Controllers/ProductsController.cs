using Ecommerce.Application.Dto;
using Ecommerce.Application.Handlers.Products.Queries;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Handlers.Categories.Queries;
using Ecommerce.Application.Handlers.Colors.Queries;
using Ecommerce.Application.Handlers.Products.Commands;
using Ecommerce.Application.Handlers.Products.Queries;
using Ecommerce.Application.Handlers.Sizes.Queries;
using Ecommerce.Domain.Constants;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Web.Mvc.Helpers;
using Ecommerce.Web.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Ecommerce.Application.Handlers.Configuration.Queries;
using Ecommerce.Application.Handlers.RenderItems.Queries;
using Ecommerce.Application.Interfaces;

namespace CoreApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IKeyAccessor _keyAccessor;
        private readonly IMediator _mediator;
        public ProductsController(IKeyAccessor keyAccessor, IMediator mediator)
        {
            _keyAccessor = keyAccessor;
            _mediator = mediator;
        }


        // [AllowAnonymous]

        // [HttpGet(Name = "Products")]

        ///[Authorize(Permissions.Permissions_Product_View)]
        //public async Task<IActionResult> Get()
        //{
        //    var paging = new PageRequest().GetPageResponse(Request);
        //    var result = await _mediator.Send(new GetProductsWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

        //    var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
        //    return Ok(jsonData);
        //}
        // [AllowAnonymous]

        [HttpGet]
        [Route("Product-GetHome")]
        public async Task<IActionResult> GetHome()
        {
            // var featureProduct = await _mediator.Send(new GetFeatureProductQuery());
            // var dealOfTheDay = await _mediator.Send(new GetDealOfTheDayConfigQuery());
            var newProductShowcase = await _mediator.Send(new GetNewProductQuery());


            //ViewBag.FeatureProduct = featureProduct.ToList();
            // ViewBag.DealOfTheDay = dealOfTheDay;
            return Ok(newProductShowcase.ToArray());
            // return Ok(featureProduct.ToList());
        }
        [HttpGet]
        [Route("Product-GetProductDetail")]
        public async Task<IActionResult> GetProductDetail(int id)
        {


            return Ok("ok");
        }
    }
}
