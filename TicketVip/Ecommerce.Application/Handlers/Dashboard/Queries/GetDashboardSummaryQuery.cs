using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Constants;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;

namespace Ecommerce.Application.Handlers.Dashboard.Queries;

public class GetDashboardSummaryQuery : IRequest<DashboardDto>
{
}
public class GetDashboardSummaryQueryHandler : IRequestHandler<GetDashboardSummaryQuery, DashboardDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    private readonly IKeyAccessor _keyAccessor;
    public GetDashboardSummaryQueryHandler(IDataContext db, IMapper mapper, IKeyAccessor keyAccessor)
    {
        _db = db;
        _mapper = mapper;
        _keyAccessor = keyAccessor;
    }

    public async Task<DashboardDto> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
    {
        return new DashboardDto();
    }
}
