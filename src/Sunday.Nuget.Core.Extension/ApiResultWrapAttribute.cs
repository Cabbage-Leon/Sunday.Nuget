using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sunday.Nuget.Core.Exceptions;
using Sunday.Nuget.Core.Infrastructure;
using System;

namespace Sunday.Nuget.Core.Extension
{
    public class ApiResultWrapAttribute : ActionFilterAttribute, IApiResultWrapAttribute
    {
        public const string ServerInternalError = nameof(ServerInternalError);
        public virtual Exception OnException(Exception ex)
        {
            return ex;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var hostEnvironmenet = context.HttpContext.RequestServices.GetService<IHostingEnvironment>();
            var logger = context.HttpContext.RequestServices.GetService<ILoggerFactory>().CreateLogger(context.Controller.GetType());
            if (context.Exception != null)
            {
                ApiResult exceptionResult;
                var ex = OnException(context.Exception);
                if (ex is DomainException domainException)
                {
                    exceptionResult = new ApiResult(domainException.ErrorCode, domainException.Message);
                    logger.LogWarning(ex, $"业务异常");
                }
                else
                {
                    exceptionResult = hostEnvironmenet.IsDevelopment() ? new ApiResult(ErrorCode.UnknownError, $"Message: {ex.GetBaseException().Message} StackTrace:{ex.GetBaseException().StackTrace}") : new ApiResult(ErrorCode.UnknownError, ServerInternalError);
                    logger.LogError(ex, $"系统异常");
                }
                context.Result = new JsonResult(exceptionResult);
                context.Exception = null;
            }
            else
            {
                var actionResult = GetValue(context.Result);
                if (actionResult == null)
                {
                    context.Result = new JsonResult(new ApiResult());
                }
                else
                {
                    var resultType = typeof(ApiResult<>).MakeGenericType(actionResult.GetType());
                    context.Result = new JsonResult(Activator.CreateInstance(resultType, actionResult));
                }
            }
        }

        public object GetValue(IActionResult actionResult)
        {
            return (actionResult as JsonResult)?.Value ?? (actionResult as ObjectResult)?.Value;
        }
    }
}
