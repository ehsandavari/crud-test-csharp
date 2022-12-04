using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dto;

namespace Presentation.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class BaseController : ControllerBase
{
    protected static ApiResult ApiResult(bool isSuccess = true)
    {
        return new ApiResult(isSuccess);
    }

    protected static ApiResultWithData<TData> ApiResultWithData<TData>(TData result)
    {
        return new ApiResultWithData<TData>(result);
    }
}