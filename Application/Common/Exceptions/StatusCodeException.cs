using System.Net;

namespace BUGgalteriyaAPI.Application.Common.Exceptions;

public class StatusCodeExeption : Exception
{
    public HttpStatusCode StatusCode { get; }

    public StatusCodeExeption(HttpStatusCode code, string message)
        : base(message)
    {
        StatusCode = code;
    }
}