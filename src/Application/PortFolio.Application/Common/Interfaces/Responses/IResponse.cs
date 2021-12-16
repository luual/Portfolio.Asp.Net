using MediatR;

namespace PortFolio.Application.Common.Interfaces.Responses;

public interface IResponse<T> : IRequest<T>
{
    T Data { get; }
    bool Error { get; }
    string Message { get; }
}