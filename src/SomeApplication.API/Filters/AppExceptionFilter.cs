using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SomeApplication.Business.Exceptions;

namespace SomeApplication.API.Filters
{
    public class AppExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger<AppExceptionFilter> logger;

        public int Order => int.MaxValue - 15;

        public AppExceptionFilter(ILogger<AppExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is null)
            {
                return;
            }

            this.logger.LogError(context.Exception, "[Global Exception Handler] Error: " + context.Exception.Message);

            switch (context.Exception)
            {
                case NotFoundException ex:
                    this.HandleNotFoundException(context, ex);
                    break;
                default:
                    context.ExceptionHandled = false;
                    break;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        private void HandleNotFoundException(ActionExecutedContext context, NotFoundException exception)
        {
            context.Result = new ObjectResult(exception.Message)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };

            context.ExceptionHandled = true;
        }
    }
}
