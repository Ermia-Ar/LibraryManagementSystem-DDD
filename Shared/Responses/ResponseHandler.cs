namespace Shared.Responses;

public static class ResponseHandler
{
    public static Response<T> Success<T>(T entity, string? message)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            IsSuccess = true,
            Message = message,
            Meta = nameof(T)
        };
    } 
    public static Response Success<T>(string? message)
    {
        return new Response()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            IsSuccess = true,
            Message = message,
            Meta = nameof(T)
        };
    }

    public static Response Unauthorized(string massege)
    {
        return new Response()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            IsSuccess = true,
            Message = massege
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
}