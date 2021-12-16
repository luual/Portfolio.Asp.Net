using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Responses;

namespace PortFolio.Application.Commands.SimpleData
{
    public class CreateSimpleDataCommand : IRequest<int>
    {
    }

    public class CreateSimpleData : IRequestHandler<CreateSimpleDataCommand, int>
    {
        public Task<int> Handle(CreateSimpleDataCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


    public class UpdateSimpleDataCommand : IRequestWrapper<int>
    {

    }

    public class UpdateSimpleDataHandler : IWrappedRequestHandler<UpdateSimpleDataCommand, int>
    {
        public Task<IResponse<int>> Handle(UpdateSimpleDataCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
