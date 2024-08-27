using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System.Text.Json;

namespace Ecommerce.Application.Handlers.TicketBooking.Commands;

public class CreateTicketBookingCommand : IRequest<Response<string>>
{
    public long Id { get; set; }
    public string DoiTac { get; set; }
    public string MaDonHang { get; set; }
    public string SanphamDichvu { get; set; }
    public double Tongtien { get; set; }
    public string Ngaydathang { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Note { get; set; }
    public string UserName { get; set; }
    public int Status { get; set; }
    public TicketType TongNguoiLon { get; set; }
    public TicketType TongTreEm { get; set; }
    public string? LoaiThanhToan { get; set; }
    public string? TongNguoiLons => JsonSerializer.Serialize<TicketType>(TongNguoiLon);
    public string? TongTreEms => JsonSerializer.Serialize<TicketType>(TongTreEm);
    public string? KeySpecs { get; set; }
    public List<string> KeySpecsList => JsonSerializer.Deserialize<List<string>>(KeySpecs ?? "[]");

}

public class CreateTicketBookingCommandHandler : IRequestHandler<CreateTicketBookingCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public CreateTicketBookingCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(CreateTicketBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = _mapper.Map<TicketBook>(request);
            var addItem = await _db.TicketBooks.AddAsync(item);
            await _db.SaveChangesAsync(cancellationToken);
            return Response<string>.Success(item.Name, "Thành công");
        }
        //catch (ValidationException e)
        //{
        //    Console.WriteLine(e);
        //    return Response<string>.Fail("Failed to add the product");
        //}
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Response<string>.Fail("Failed to add the product");
        }
    }
}
