﻿using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Commands;

public class PortfolioCategoryCommand : IRequest<Response<string>>
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
    public string Slug { get; set; }
    public string Desciption { get; set; }
    public string? Icon { get; set; }
    public string? ImageBanner { get; set; }



  

}
public class PortfolioCategoryCommandHandler : IRequestHandler<PortfolioCategoryCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public PortfolioCategoryCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(PortfolioCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = _db.PortfolioCategorys.FirstOrDefault(c => c.Name == request.Name || c.Slug == request.Slug);

        if (existingCategory != null)
        {
            var errorMsg = "This Category Related Data Already Exist. Please Change those Data.";
            if (existingCategory.Name == request.Name) errorMsg += $" Name:[{existingCategory.Name}],";
            if (existingCategory.Slug == request.Slug) errorMsg += $" Slug:[{existingCategory.Slug}]";
            return Response<string>.Fail(errorMsg);
        }

        try
        {
            var category = _mapper.Map<Ecommerce.Domain.Entities.PortfolioCategory>(request);
            var addcategory = await _db.PortfolioCategorys.AddAsync(category);
            await _db.SaveChangesAsync(cancellationToken);
            return Response<string>.Success(category.Name, "Successfully created");
        }
        //catch (ValidationException e)
        //{
        //    Console.WriteLine(e);
        //    return Response<string>.Fail("Failed to add item!");
        //}
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Response<string>.Fail("Failed to add item!");
        }
    }
}
