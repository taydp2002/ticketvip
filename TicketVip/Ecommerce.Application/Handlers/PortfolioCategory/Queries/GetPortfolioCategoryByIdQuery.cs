using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using MediatR;

namespace Ecommerce.Application.Handlers.CategoryPortfolioCategoryries.Queries;

public class GetPortfolioCategoryByIdQuery : IRequest<PortfolioCategoryDto>
{
    public int Id { get; set; }
}
public class GetPortfolioCategoryByIdQueryHandler : IRequestHandler<GetPortfolioCategoryByIdQuery, PortfolioCategoryDto>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetPortfolioCategoryByIdQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PortfolioCategoryDto> Handle(GetPortfolioCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _db.PortfolioCategorys.FindAsync(request.Id);
        var result = _mapper.Map<PortfolioCategoryDto>(category);
        return result;
    }
}
