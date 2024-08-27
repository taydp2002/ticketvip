using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.Dashboard.Queries;

public class GetWeeklyItemSalesAmountQuery : IRequest<List<WeeklySalesAmount>>
{
}
public class GetWeeklyItemSalesAmountQueryHandler : IRequestHandler<GetWeeklyItemSalesAmountQuery, List<WeeklySalesAmount>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetWeeklyItemSalesAmountQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<WeeklySalesAmount>> Handle(GetWeeklyItemSalesAmountQuery request, CancellationToken cancellationToken)
    {
       

        return new List<WeeklySalesAmount>();
    }
}
