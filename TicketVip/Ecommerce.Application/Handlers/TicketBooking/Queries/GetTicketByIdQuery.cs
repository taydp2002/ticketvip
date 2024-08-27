using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.TicketBooking.Queries;

public class GetTicketByIdQuery : IRequest<TicketBookDto>
{
    public long Id { get; set; }
}
public class GetTicketIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketBookDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetTicketIdQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<TicketBookDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await (from p in _db.TicketBooks             
                       where p.Id == request.Id
                       select new TicketBookDto
                       {
                           Id = p.Id,
                           Name = p.Name,
                           DoiTac=p.DoiTac,
                           SanphamDichvu=p.SanphamDichvu,
                           Email=p.Email,
                           Phone=p.Phone,
                           Address=p.Address,
                           Note=p.Note,
                           Tongtien=p.Tongtien,
                           Ngaydathang=p.Ngaydathang,
                           MaDonHang=p.MaDonHang,
                           UserName=p.UserName,
                           Status=p.Status,
                       }).FirstOrDefaultAsync(cancellationToken);

        return product;
    }
}
