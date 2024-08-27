using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Commands;

public class UpdatePortfolioCategoryCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int? ParentCategoryId { get; set; }
        public string Desciption { get; set; }
    public string? Icon { get; set; }
    public string? ImageBanner { get; set; }
}
public class UpdatePortfolioCategoryCommandHandler : IRequestHandler<UpdatePortfolioCategoryCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public UpdatePortfolioCategoryCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(UpdatePortfolioCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _db.PortfolioCategorys.FindAsync(request.Id);
            _mapper.Map(request, category);
            _db.PortfolioCategorys.Update(category);
            await _db.SaveChangesAsync(cancellationToken);
            return Response<string>.Success(category.Name, "Cập nhật thành công");
        }
        catch (Exception e)
        {
            return Response<string>.Fail("Lỗi rồi bạn nhé");
        }
    }
}
