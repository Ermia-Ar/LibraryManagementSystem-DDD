using System.Net;
using Shared.Responses;
using Microsoft.AspNetCore.Http;
using Shared.Exceptions;

namespace Shared.Middleware;

	public class ErrorHandlerMiddleware(RequestDelegate next)
	{
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception error)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				var responseModel = new Response{ IsSuccess = false, Message = error.Message };

                switch (error)
				{  
					case BaseDomainException e:
						// custom application error
						responseModel.Message = null;
						responseModel.StatusCode = HttpStatusCode.BadRequest;
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						responseModel.Errors = e.Errors;
						break;
					
					case BaseValidationException e:
						responseModel.Message = null;
						responseModel.StatusCode = (HttpStatusCode)422;
						response.StatusCode = 422;
						responseModel.Errors = e.Errors;
						break;
					
					case { } e:
						if (e.GetType().ToString() == "ApiException")
						{
							responseModel.Message += e.Message;
							responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;
							responseModel.StatusCode = HttpStatusCode.BadRequest;
							response.StatusCode = (int)HttpStatusCode.BadRequest;
						}
						responseModel.Message = e.Message;
						responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;

						responseModel.StatusCode = HttpStatusCode.InternalServerError;
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;

					default:
						responseModel.Message = error.Message;
						responseModel.StatusCode = HttpStatusCode.InternalServerError;
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}
				var result = Json.Json.Serialize(responseModel);

				await response.WriteAsync(result);
			}
		}
	}
	