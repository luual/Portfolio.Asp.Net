using MediatR;

namespace PortFolio.Application.Common.Interfaces.Responses;

public interface IWrappedRequestHandler<in TIn, TOut> : IRequestHandler<TIn, IResponse<TOut>>
    where TIn : IRequestWrapper<TOut>
{
}