using System.Diagnostics.Contracts;
using MediatR;

namespace PortFolio.Application.Common.Interfaces.Responses;

public interface IResponse<T> : IRequest<T>
{
    T Data { get; }
    bool Error { get; }
    string Message { get; }
}

public class ResponseHandler<T> : IResponse<T>
{
    public T Data { get; }
    public bool Error { get; }
    public string Message { get; }
    
    public ResponseHandler(T data, bool error, string message)
    {
        Data = data;
        Error = error;
        Message = message;
    }
}

public static class ResponseHelper
{
    public static IResponse<T> Fail<T>(T data, string message = null) => 
        new ResponseHandler<T>(data, true, message);

    public static IResponse<T> Ok<T>(T data, string message = null) =>
        new ResponseHandler<T>(data, false, message);
}