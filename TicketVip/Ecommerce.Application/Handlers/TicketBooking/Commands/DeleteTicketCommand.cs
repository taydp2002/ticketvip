using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Commands;

public class DeleteTicketCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public DeleteTicketCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _db.TicketBooks.Where(o => o.Id == request.Id).FirstOrDefaultAsync(); ;
            _db.TicketBooks.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);
            return Response<string>.Success(category.Name, "Xóa thành công");
        }
        catch (Exception e)
        {
            return Response<string>.Fail(e.Message);
        }
    }
}
