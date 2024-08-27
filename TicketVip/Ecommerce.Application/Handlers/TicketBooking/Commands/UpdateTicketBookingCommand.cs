using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.TicketBooking.Commands
{
    public class UpdateTicketBookingCommand : IRequest<Response<string>>
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public class UpdateTicketBookingCommandHandler : IRequestHandler<UpdateTicketBookingCommand, Response<string>>
        {
            private readonly IDataContext _db;
            private readonly IMapper _mapper;
            public UpdateTicketBookingCommandHandler(IDataContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Response<string>> Handle(UpdateTicketBookingCommand request, CancellationToken cancellationToken)
            {
                //try
                //{
                var product = await _db.TicketBooks.FindAsync(request.Id);
                product.UserName = request.UserName;
                product.Status = 2;
                // _mapper.Map(request, product);
                _db.TicketBooks.Update(product);
                await _db.SaveChangesAsync(cancellationToken);
                return Response<string>.Success(product.Name, "Successfully updated the Ticket");


                // }
                //catch (ValidationException e)
                //{
                //    Console.WriteLine(e);
                //    return Response<string>.Fail("Failed to add the product");
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    return Response<string>.Fail("Failed to add the product");
                //}
            }
        }
    }
}
