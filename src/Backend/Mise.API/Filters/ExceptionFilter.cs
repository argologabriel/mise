using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mise.Communication.Responses;

namespace Mise.Exceptions.ExceptionsBase;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is MiseException)
		{
			HandleProjectException(context);
		}
		else 
		{
			ThrowUnknowException(context);
		}
	}

	private void HandleProjectException(ExceptionContext context)
	{
		if (context.Exception is ValidationErrorException)
		{
			var exception = context.Exception as ValidationErrorException;

			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));
		}
	}

	private void ThrowUnknowException(ExceptionContext context)
	{
		context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido."));
	}
}
