using System.Net;

namespace Application.Common.Exceptions;

public class BaseHttpException : Exception
{
    public BaseHttpException(HttpStatusCode httpStatusCode, HttpExceptionTypes httpExceptionType)
    {
        HttpStatusCode = httpStatusCode;
        HttpExceptionType = httpExceptionType;
    }

    public HttpStatusCode HttpStatusCode { get; }

    public HttpExceptionTypes HttpExceptionType { get; }
}