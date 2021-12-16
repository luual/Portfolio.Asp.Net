using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;

namespace PortFolio.Application.Queries;

public class GetSimpleDataQuery : IRequest<string[]>
{
}

public class GetSimpleDataQueryHandler : IRequestHandler<GetSimpleDataQuery, string[]>
{
    private readonly ISimpleDataRepository _simpleDataRepository;

    public GetSimpleDataQueryHandler(ISimpleDataRepository simpleDataRepository)
    {
        _simpleDataRepository = simpleDataRepository;
    }

    public Task<string[]> Handle(GetSimpleDataQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_simpleDataRepository?.Get()?.ToArray());
    }
}