using Ecommerce.Application.Handlers.PortfolioCategory.Queries;

using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Mvc.Views.Shared.Components.NewArrival;

public class HomeDoiTacViewComponent : ViewComponent
{
    private readonly IKeyAccessor _keyAccessor;
    private readonly IMediator _mediator;

    public HomeDoiTacViewComponent(IKeyAccessor keyAccessor, IMediator mediator)
    {
        _keyAccessor = keyAccessor;
        _mediator = mediator;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var newProductShowcase = await _mediator.Send(new GetPortfolioCategoryQuery());
        return View(newProductShowcase);
    }
}
