using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TimeMark.Filters
{
	public class ApiExceptionFilter : IExceptionFilter
	{
		private readonly ILogger<ApiExceptionFilter> _logger;

		public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
		{
			_logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			_logger.LogError(context.Exception, "Unhandled exception occurred.");

			context.Result = new ObjectResult(new
			{
				Message = "An unexpected error occurred.",
				Error = context.Exception.Message
			})
			{
				StatusCode = 500
			};

			context.ExceptionHandled = true;
		}
	}
}