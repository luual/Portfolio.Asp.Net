using MediatR;

namespace PortFolio.Application.Common.Interfaces.Responses
{
    public interface IRequestWrapper<T> : IRequest<IResponse<T>>
    {

    }
}