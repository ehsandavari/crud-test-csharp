using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Dto;

namespace Presentation.Filters;

public class ApiActionFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        var validationProblemDetails = new ValidationProblemDetails(context.ModelState);
        context.Result = new BadRequestObjectResult
        (
            new ApiResultWithMetaData
            (
                new MetaData("ValidationException", StatusCodes.Status400BadRequest, validationProblemDetails.Errors)
            )
        );
    }
}