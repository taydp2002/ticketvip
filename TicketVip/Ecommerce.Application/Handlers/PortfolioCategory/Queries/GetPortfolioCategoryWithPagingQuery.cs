using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Queries;

public class GetPortfolioCategoryWithPagingQuery : IRequest<PaginatedList<PortfolioCategoryDto>>
{
    public int? page { get; set; }
    public int length { get; set; }
    public string searchValue { get; set; } = "";
    public string sortColumn { get; set; } = "Id";
    public string sortOrder { get; set; } = "Desc";
}
public class GetAllProductQueryHandler : IRequestHandler<GetPortfolioCategoryWithPagingQuery, PaginatedList<PortfolioCategoryDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetAllProductQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PortfolioCategoryDto>> Handle(GetPortfolioCategoryWithPagingQuery request, CancellationToken cancellationToken)
    {
        var categories = _db.PortfolioCategorys.OrderByDescending(o => o.LastModifiedDate).AsQueryable();
        var getcategories =
                categories
                .Where(a => a.Name.ToLower().Contains(request.searchValue))
                .OrderBy($"{request.sortColumn} {request.sortOrder}").ProjectTo<PortfolioCategoryDto>(_mapper.ConfigurationProvider);

        var data = await PaginatedList<PortfolioCategoryDto>.CreateAsync(getcategories, request.page ?? 1, request.length);


        return data;
    }
}
