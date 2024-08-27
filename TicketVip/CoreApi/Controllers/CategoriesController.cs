using AutoMapper;
using Ecommerce.Application.Handlers.BlogCategory.Queries;
using Ecommerce.Application.Handlers.Categories.Commands;
using Ecommerce.Application.Handlers.Categories.Queries;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Web.Mvc.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var kq = await _mediator.Send(new GetBlogCategoryQuery());
        //    return Ok(kq.ToArray());
        //}
        [HttpGet]
        [Route("Category-RenderView")]
        public async Task<IActionResult> RenderView()
        {
            var paging = new PageRequest().GetPageResponse(Request);
            var result = await _mediator.Send(new GetCategoriesWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

            var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
            return Ok(jsonData);
        }

        [HttpGet]
        [Route("Category-GetCategoriesBySub")]
        public async Task<IActionResult> GetCategoriesBySub()
        {
            var result = await _mediator.Send(new GetAllCategoriesWithChildrenQuery());
            return Ok(result);
        }

        //[Authorize(Permissions.Permissions_Category_Create)]
        //public async Task<IActionResult> Create()
        //{
        //    ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetCategoriesQuery()), "Id", "Name");
        //    return View();
        //}

        [HttpPost]
       // [ValidateAntiForgeryToken]
        // [Authorize(Permissions.Permissions_Category_Create)]
        [Route("Category-Create")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            
          //  if (!ModelState.IsValid) return View(command);
            var response = await _mediator.Send(command);
           // if (response.Succeeded) return RedirectToAction(nameof(Index));

           // ModelState.AddModelError(string.Empty, response.Message);

          //  ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetCategoriesQuery()), "Id", "Name");
           // return View(command);
            return Ok(response);
        }

        //[Authorize(Permissions.Permissions_Category_Edit)]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetCategoriesQuery()), "Id", "Name");

        //    var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
        //    return View(updateCategoryCommand);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Permissions.Permissions_Category_Edit)]
        //public async Task<IActionResult> Edit(UpdateCategoryCommand command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (command.Slug == null)
        //        {
        //            command.Slug = command.Name.ToLower().Replace(" ", "-");
        //        }
        //        else
        //        {
        //            command.Slug = command.Slug.ToLower().Replace(" ", "-");
        //        }
        //        var response = await _mediator.Send(command);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetCategoriesQuery()), "Id", "Name");
        //    return View(command);
        //}

        [HttpPost]
        [Route("Category-Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return Ok(response);
        }

        //[HttpPost]
        [HttpGet]
        [Route("Category-GetAllCategoriesWithChildren")]
        public async Task<IActionResult> GetAllCategoriesWithChildren()
        {
            var result = await _mediator.Send(new GetAllCategoriesWithChildrenQuery());
            return Ok(result);
        }
    }
}
