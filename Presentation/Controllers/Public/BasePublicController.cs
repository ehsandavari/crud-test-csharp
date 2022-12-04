using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Public;

[ApiExplorerSettings(GroupName = "public")]
[Route("public/[controller]/[action]")]
public class BasePublicController : BaseController
{
}