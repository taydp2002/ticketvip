using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Commands;

public class DeletePortfolioCategoryCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}

public class DeletePortfolioCategoryCommandHandler : IRequestHandler<DeletePortfolioCategoryCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public DeletePortfolioCategoryCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(DeletePortfolioCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _db.PortfolioCategorys.Where(o => o.Id == request.Id).FirstOrDefaultAsync(); ;
            _db.PortfolioCategorys.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);
            return Response<string>.Success(category.Name, "Xóa thành công");
        }
        catch (Exception e)
        {
            return Response<string>.Fail(e.Message);
        }
    }
}
