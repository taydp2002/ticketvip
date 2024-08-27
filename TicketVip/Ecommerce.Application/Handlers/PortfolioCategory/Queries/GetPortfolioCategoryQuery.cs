using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Queries;

public class GetPortfolioCategoryQuery : IRequest<IEnumerable<PortfolioCategoryDto>>
{
}
public class GetPortfolioQueryHandler : IRequestHandler<GetPortfolioCategoryQuery, IEnumerable<PortfolioCategoryDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetPortfolioQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PortfolioCategoryDto>> Handle(GetPortfolioCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _db.PortfolioCategorys.OrderByDescending(o => o.LastModifiedDate).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<PortfolioCategoryDto>>(categories);
        return result.AsReadOnly();
    }
}
