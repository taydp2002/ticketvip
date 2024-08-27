using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Handlers.Booking.Commands;

public class CreateBookingCommand : IRequest<Response<string>>
{
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public float? Amount { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? Enđate { get; set; }

    public int Status { get; set; }



}
public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Response<string>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public CreateBookingCommandHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        //var existingCategory = _db.BlogCategorys.FirstOrDefault(c => c.Name == request.Name || c.Slug == request.Slug);

        //if (existingCategory != null)
        //{
        //    var errorMsg = "This Category Related Data Already Exist. Please Change those Data.";
        //    if (existingCategory.Name == request.Name) errorMsg += $" Name:[{existingCategory.Name}],";
        //    if (existingCategory.Slug == request.Slug) errorMsg += $" Slug:[{existingCategory.Slug}]";
        //    return Response<string>.Fail(errorMsg);
        //}

        try
        {
            var category = _mapper.Map<Ecommerce.Domain.Entities.Booking>(request);
            var addcategory = await _db.Bookings.AddAsync(category);
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
