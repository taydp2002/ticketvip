using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Queries;

public class GetPortfolioCategoryByProductQuery : IRequest<PortfolioCategoryDto>
{
    public int Id { get; set; }
}
public class GetPortfolioCategoryByProductQueryHandler : IRequestHandler<GetPortfolioCategoryByProductQuery, PortfolioCategoryDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetPortfolioCategoryByProductQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PortfolioCategoryDto> Handle(GetPortfolioCategoryByProductQuery request, CancellationToken cancellationToken)
    {
        return new PortfolioCategoryDto();
    }
}
