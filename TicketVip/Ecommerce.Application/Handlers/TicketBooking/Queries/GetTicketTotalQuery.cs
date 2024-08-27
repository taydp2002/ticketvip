using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.TicketBooking.Queries;
public class TicketTotal
{
    public int TongVe { get; set; }
    public double Total { get; set; }
    
}
public class GetTicketTotalQuery : IRequest<TicketTotal>
{
    public string User { get; set; }
    public int Type { get; set; }

}
public class GetTicketTicketTotalQueryHandler : IRequestHandler<GetTicketTotalQuery, TicketTotal>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetTicketTicketTotalQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<TicketTotal> Handle(GetTicketTotalQuery request, CancellationToken cancellationToken)
    {
        TicketTotal kq=new TicketTotal();
        if (request.Type==1)
        {
            var count = await _db.TicketBooks.Where(x => x.DoiTac == request.User).CountAsync();

            var total = await _db.TicketBooks.Where(x => x.DoiTac == request.User).SumAsync(x => x.Tongtien);

            kq.Total = total;
            kq.TongVe = count;
        }
        else
        {
            var count = await _db.TicketBooks.CountAsync();

            var total = await _db.TicketBooks.SumAsync(x => x.Tongtien);

            kq.Total = total;
            kq.TongVe = count;

        }
        
        
        return kq;
    }
}
