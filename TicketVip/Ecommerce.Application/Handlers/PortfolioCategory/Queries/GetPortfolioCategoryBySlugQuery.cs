using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Queries;

public class GetPortfolioCategoryBySlugQuery : IRequest<PortfolioCategoryDto>
{
    public string Slug { get; set; }
}
public class GetPortfolioCategoryBySlugQueryHandler : IRequestHandler<GetPortfolioCategoryBySlugQuery, PortfolioCategoryDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetPortfolioCategoryBySlugQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PortfolioCategoryDto> Handle(GetPortfolioCategoryBySlugQuery request, CancellationToken cancellationToken)
    {
        var category = await _db.PortfolioCategorys.Where(o => o.Slug == request.Slug).FirstOrDefaultAsync();
        var result = _mapper.Map<PortfolioCategoryDto>(category);
        return result;
    }
}
