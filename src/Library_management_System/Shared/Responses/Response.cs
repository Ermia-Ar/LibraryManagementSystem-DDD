using System.Net;

namespace Shared.Responses;


public class Response<T> : Response
{
	public T Data { get; set; }

}

public class Response
{
	public HttpStatusCode StatusCode { get; set; }

	public bool IsFailed => !IsSuccess;

	public object? Meta { get; set; }

	public bool IsSuccess { get; set; }

	public string? Message { get; set; } = null!;

	public List<string> Errors { get; set; } = null!;
}