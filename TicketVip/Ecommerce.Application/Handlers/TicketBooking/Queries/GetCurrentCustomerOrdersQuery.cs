using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.Orders.Queries;

public class GetCurrentCustomerTicketBookingQuery : IRequest<List<TicketBookOrderDto>>
{
    public string UserName;
}
public class GetCurrentCustomerTicketBookingQueryHandler : IRequestHandler<GetCurrentCustomerTicketBookingQuery, List<TicketBookOrderDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    public GetCurrentCustomerTicketBookingQueryHandler(IDataContext db, IMapper mapper, ICurrentUser currentUser)
    {
        _db = db;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<List<TicketBookOrderDto>> Handle(GetCurrentCustomerTicketBookingQuery request, CancellationToken cancellationToken)
    {
        var customer = await _db.Customers.Where(c => c.ApplicationUserId == _currentUser.UserId)
            .FirstOrDefaultAsync(cancellationToken);


        if(customer == null) return new List<TicketBookOrderDto>();
        var orders = await _db.TicketBooks.AsNoTracking()             
            .Where(o => o.UserName == request.UserName)
            .Select(o => new TicketBookOrderDto
            {
               Name= o.UserName,
               Address= o.Address,
               Tongtien= o.Tongtien,
               Phone=o.Phone,
               Email=o.Email,
               UserName=o.UserName,
               DoiTac=o.DoiTac,
               Id=o.Id,
               MaDonHang=o.MaDonHang,
               SanphamDichvu= o.SanphamDichvu,
               Ngaydathang=o.Ngaydathang,
               Note= o.Note,
               Status = o.Status,
               CreatedDate=o.CreatedDate,
               LastModifiedDate=o.LastModifiedDate,
            })
            .OrderByDescending(c=>c.Id).ToListAsync(cancellationToken);

        return orders;
    }
}
