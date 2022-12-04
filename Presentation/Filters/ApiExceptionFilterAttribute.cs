using Application.Common.Exceptions;
using Application.Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Extensions;
using Presentation.Dto;

namespace Presentation.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
    private readonly IStringLocalizer<Messages> _localizer;

    public ApiExceptionFilterAttribute(IStringLocalizer<Messages> localizer)
    {
        _localizer = localizer;
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(BaseHttpException), HandleBaseHttpException}
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
            return;
        }

        var type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private static void HandleInvalidModelStateException(ExceptionContext context)
    {
        var details = new ValidationProblemDetails(context.ModelState);

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandleBaseHttpException(ExceptionContext context)
    {
        var baseHttpException = (context.Exception as BaseHttpException)!;
        context.Result =
            new ObjectResult(
                new ApiResultWithMetaData(new MetaData(baseHttpException.HttpExceptionType.GetDisplayName(),
                    _localizer[baseHttpException.HttpExceptionType.GetDisplayName()].Value)))
            {
                StatusCode = (int) baseHttpException.HttpStatusCode
            };
        context.ExceptionHandled = true;
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Detail = context.Exception.Message
        };

        context.Result =
            new ObjectResult(
                new ApiResultWithMetaData(new MetaData(context.Exception.GetType().Name, details)))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        context.ExceptionHandled = true;
    }
}