using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto;
using Ecommerce.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text.Json;

namespace Ecommerce.Application.Handlers.Configuration.Queries;

public class GetFeatureProductConfigurationQuery : IRequest<List<FeatureProductConfigurationDto>>
{
}
public class GetFeatureProductConfigurationQueryHandler : IRequestHandler<GetFeatureProductConfigurationQuery, List<FeatureProductConfigurationDto>>
{
    private readonly IDataContext _db;
    private readonly IMapper _mapper;
    public GetFeatureProductConfigurationQueryHandler(IDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<FeatureProductConfigurationDto>> Handle(GetFeatureProductConfigurationQuery request, CancellationToken cancellationToken)
    {

        return new List<FeatureProductConfigurationDto>();
    }

}
