using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.Dashboard.Queries;

public class GetWeeklyItemSalesCountQuery : IRequest<List<WeeklyItemSalesCount>>
{
}
public class GetWeeklyItemSalesCountQueryHandler : IRequestHandler<GetWeeklyItemSalesCountQuery, List<WeeklyItemSalesCount>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetWeeklyItemSalesCountQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<WeeklyItemSalesCount>> Handle(GetWeeklyItemSalesCountQuery request, CancellationToken cancellationToken)
    {

        return new List<WeeklyItemSalesCount>();
    }
}
