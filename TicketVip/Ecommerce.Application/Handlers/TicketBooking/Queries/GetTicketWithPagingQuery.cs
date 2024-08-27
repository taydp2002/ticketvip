using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;
using Ecommerce.Application.Helpers;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ecommerce.Application.Handlers.PortfolioCategory.Queries;

public class GetTicketWithPagingQuery : IRequest<PaginatedList<TicketBookDto>>
{
    public int? page { get; set; }
    public int length { get; set; }
    public string searchValue { get; set; } = "";
    public string sortColumn { get; set; } = "Id";
    public string sortOrder { get; set; } = "Desc";
    public string UserName { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
}
public class GetAllTicketQueryHandler : IRequestHandler<GetTicketWithPagingQuery, PaginatedList<TicketBookDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetAllTicketQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TicketBookDto>> Handle(GetTicketWithPagingQuery request, CancellationToken cancellationToken)
    {

        IQueryable<TicketBook> categories;
        //DoiTac
        if (request.Type==1)
        {
              categories = _db.TicketBooks.Where(x => x.DoiTac==request.UserName).OrderByDescending(o => o.LastModifiedDate).AsQueryable();
        }
        else
        {
            if (request.Type == 2)
            {

                 categories = _db.TicketBooks.Where(x => x.UserName==request.UserName).OrderByDescending(o => o.LastModifiedDate).AsQueryable();
            }
            else
            {
                 categories = _db.TicketBooks.OrderByDescending(o => o.LastModifiedDate).AsQueryable();

            }
        }
      

        var getcategories =
                categories
                .Where(a => a.Name.ToLower().Contains(request.searchValue) || a.DoiTac.Contains(request.searchValue) || a.Phone.Contains(request.searchValue))
                .OrderBy($"{request.sortColumn} {request.sortOrder}").ProjectTo<TicketBookDto>(_mapper.ConfigurationProvider);

        if (request.Status != 0)
        {
            getcategories = getcategories.Where(x => x.Status == request.Status);
        }

        //if (getcategories.Count()==0)
        //{
        //    getcategories =
        //            categories
        //            .Where(a => a.DoiTac.ToLower().Contains(request.searchValue))
        //            .OrderBy($"{request.sortColumn} {request.sortOrder}").ProjectTo<TicketBookDto>(_mapper.ConfigurationProvider);
        //}

        var data = await PaginatedList<TicketBookDto>.CreateAsync(getcategories, request.page ?? 1, request.length);


        return data;
    }
}
