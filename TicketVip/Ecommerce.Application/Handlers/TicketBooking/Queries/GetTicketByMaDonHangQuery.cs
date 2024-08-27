using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.TicketBooking.Queries;

public class GetTicketByMaDonHangQuery : IRequest<TicketBookDto>
{
    public string MaDonHang { get; set; }
}
public class GetTicketMaDonHangQueryHandler : IRequestHandler<GetTicketByMaDonHangQuery, TicketBookDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetTicketMaDonHangQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<TicketBookDto> Handle(GetTicketByMaDonHangQuery request, CancellationToken cancellationToken)
    {
        var product = await (from p in _db.TicketBooks             
                       where p.MaDonHang == request.MaDonHang
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
                           TongNguoiLons=p.TongNguoiLons,
                           TongTreEms=p.TongTreEms
                       }).FirstOrDefaultAsync(cancellationToken);

        return product;
    }
}
