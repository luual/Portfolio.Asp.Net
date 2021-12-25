using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;

namespace PortFolio.Application.Queries;

public class GetSimpleDataQuery : IRequest<string[]>
{
}

public class GetSimpleDataQueryHandler : IRequestHandler<GetSimpleDataQuery, string[]>
{
    private readonly ISimpleDataRepository _simpleDataRepository;
    private readonly IMapper _mapper;

    public GetSimpleDataQueryHandler(ISimpleDataRepository simpleDataRepository, IMapper mapper)
    {
        _simpleDataRepository = simpleDataRepository;
        _mapper = mapper;
    }

    public Task<string[]> Handle(GetSimpleDataQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_simpleDataRepository?.Get()?.ToArray());
    }
}