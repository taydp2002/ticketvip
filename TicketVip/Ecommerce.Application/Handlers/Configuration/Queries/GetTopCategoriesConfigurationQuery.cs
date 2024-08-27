using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Domain.Constants;
using Ecommerce.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text.Json;

namespace Ecommerce.Application.Handlers.Configuration.Queries;

public class GetTopCategoriesConfigurationQuery : IRequest<List<TopCategoriesConfigurationDto>>
{
}
public class GetTopCategoriesConfigurationQueryHandler : IRequestHandler<GetTopCategoriesConfigurationQuery, List<TopCategoriesConfigurationDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetTopCategoriesConfigurationQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TopCategoriesConfigurationDto>> Handle(GetTopCategoriesConfigurationQuery request, CancellationToken cancellationToken)
    {
        
        return new List<TopCategoriesConfigurationDto>();
    }

}
