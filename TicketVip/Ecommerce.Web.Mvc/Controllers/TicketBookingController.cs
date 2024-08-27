using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Application.Handlers.TicketBooking.Commands;

namespace Ecommerce.Web.Mvc.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly IMediator _mediator;
        public TicketBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Permissions.Permissions_Product_View)]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Permissions.Permissions_Product_View)]
        //public async Task<IActionResult> RenderView()
        //{
        //    var paging = new PageRequest().GetPageResponse(Request);
        //    var result = await _mediator.Send(new GetPortfolioWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

        //    var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
        //    return Json(jsonData);
        //}

        [Authorize(Permissions.Permissions_Product_Create)]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Permissions_Product_Create)]
        public async Task<IActionResult> Create(CreateTicketBookingCommand command)
        {
          
            //var checkSlug = await _mediator.Send(new GetPortfolioBySlugQuery { Slug = command.Slug });
            //if (checkSlug != null)
            //{
            //    ModelState.AddModelError(string.Empty, "Lỗi trùng Slug url bài viết");
            //    return View(command);
            //}
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(command);
                if (response.Succeeded) return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, response.Message);
            }
            //return Json(new JsonResponse { Success = false, Error = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray() });

            return View(command);
        }
        [Authorize(Permissions.Permissions_Product_Edit)]
        public async Task<IActionResult> Details(int id)
        {
           // var response = await _mediator.Send(new GetPortfolioByIdQuery { Id = id });
     

            return View();
        }

    
        //[HttpPost]
        //[Authorize(Permissions.Permissions_Product_Edit)]
        //public async Task<IActionResult> Update(PortfolioDto data)
        //{
        //    if (data != null)
        //    {
        //        var response = await _mediator.Send(new UpdatePortfolioCommand { PortfolioDto = data });
        //        // if (response.Succeeded) return Json(response.Data);
        //        if (response.Succeeded) return RedirectToAction(nameof(Index));
        //    }
        //    return Json(data);
        //}
    }
}
