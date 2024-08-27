﻿using AutoMapper;
using Ecommerce.Application.Handlers.CategoryPortfolioCategoryries.Queries;
using Ecommerce.Application.Handlers.PortfolioCategory.Commands;
using Ecommerce.Application.Handlers.PortfolioCategory.Queries;
using Ecommerce.Domain.Identity.Permissions;
using Ecommerce.Web.Mvc.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Mvc.Controllers;

[Authorize]
public class PortfolioCategoryController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PortfolioCategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize(Permissions.Permissions_PortfolioCategory_View)]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize(Permissions.Permissions_PortfolioCategory_View)]
    public async Task<IActionResult> RenderView()
    {
        var paging = new PageRequest().GetPageResponse(Request);
        var result = await _mediator.Send(new GetPortfolioCategoryWithPagingQuery { page = paging.PageIndex, length = paging.Length, searchValue = paging.SearchValue, sortColumn = paging.SortColumnName, sortOrder = paging.SortOrder });

        var jsonData = new { data = result.Items, draw = paging.Draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount };
        return Json(jsonData);
    }

    [HttpGet]
    [Authorize(Permissions.Permissions_PortfolioCategory_View)]
    public async Task<IActionResult> GetCategoriesBySub()
    {
       
        return Json(Ok(""));
    }

    [Authorize(Permissions.Permissions_PortfolioCategory_Create)]
    public async Task<IActionResult> Create()
    {
        ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetPortfolioCategoryQuery()), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Permissions.Permissions_PortfolioCategory_Create)]
    public async Task<IActionResult> Create(PortfolioCategoryCommand command)
    {
        if (!ModelState.IsValid) return View(command);
        var response = await _mediator.Send(command);
        if (response.Succeeded) return RedirectToAction(nameof(Index));

        ModelState.AddModelError(string.Empty, response.Message);

        ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetPortfolioCategoryQuery()), "Id", "Name");
        return View(command);
    }

    [Authorize(Permissions.Permissions_PortfolioCategory_Edit)]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _mediator.Send(new GetPortfolioCategoryByIdQuery { Id = id });
        if (category == null)
        {
            return NotFound();
        }
        ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetPortfolioCategoryQuery()), "Id", "Name");

        var updateCategoryCommand = _mapper.Map<UpdatePortfolioCategoryCommand>(category);
        return View(updateCategoryCommand);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Permissions.Permissions_PortfolioCategory_Edit)]
    public async Task<IActionResult> Edit(UpdatePortfolioCategoryCommand command)
    {
        if (ModelState.IsValid)
        {
            if (command.Slug == null)
            {
                command.Slug = command.Name.ToLower().Replace(" ", "-");
            }
            else
            {
                command.Slug = command.Slug.ToLower().Replace(" ", "-");
            }
            var response = await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        ViewData["ParentCategoryId"] = new SelectList(await _mediator.Send(new GetPortfolioCategoryQuery()), "Id", "Name");
        return View(command);
    }

    [HttpPost]
    [Authorize(Permissions.Permissions_PortfolioCategory_Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediator.Send(new DeletePortfolioCategoryCommand { Id = id });
        return Json(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllCategoriesWithChildren()
    {
       
        return Json(Ok(""));
    }
}
