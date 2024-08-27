using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.Booking.Queries;

public class GetBookingWithPagingQuery : IRequest<PaginatedList<BookingDto>>
{
    public int? page { get; set; }
    public int length { get; set; }
    public string searchValue { get; set; } = "";
    public string sortColumn { get; set; } = "Id";
    public string sortOrder { get; set; } = "Desc";
}
public class GetAllBookingQueryHandler : IRequestHandler<GetBookingWithPagingQuery, PaginatedList<BookingDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetAllBookingQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BookingDto>> Handle(GetBookingWithPagingQuery request, CancellationToken cancellationToken)
    {
        var categories = _db.Bookings.OrderByDescending(o => o.LastModifiedDate).AsQueryable();
        var getcategories =
                categories
                .Where(a => a.Name.ToLower().Contains(request.searchValue))
                .OrderBy($"{request.sortColumn} {request.sortOrder}").ProjectTo<BookingDto>(_mapper.ConfigurationProvider);

        var data = await PaginatedList<BookingDto>.CreateAsync(getcategories, request.page ?? 1, request.length);


        return data;
    }
}
