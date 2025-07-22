using System.Net;

namespace Shared.Responses;

public static class ResponseHandler
{
    public static Response<T> Success<T>(T entity)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            IsSuccess = true,
            Meta = typeof(T).Name
        };
    } 
    public static Response Success(string? message = null, object? meta = null)
    {
        return new Response()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            IsSuccess = true,
            Message = message,
            Meta = meta
        };
    }

    public static Response Unauthorized(string messege)
    {
        return new Response()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            IsSuccess = true,
            Message = messege
        };
    }

    public static Response BadRequest(string message)
    {
        return new Response
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            IsSuccess = false,
            Message = message
        };
    }

    public static Response<T> UnprocessableEntity<T>(string message)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            IsSuccess = false,
            Message = message
        };
    }

    public static Response NotFound(string? message = null)
    {
        return new Response()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            IsSuccess = false,
            Message = message
        };
    }
    public static Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            IsSuccess = false,
            Message = message,
        };
    }

    public static Response FailureValidation(List<string> errors)
    {
        return new Response()
        {
            StatusCode = (HttpStatusCode)422,
            IsSuccess = false,
            Errors = errors,
        };
    }
}