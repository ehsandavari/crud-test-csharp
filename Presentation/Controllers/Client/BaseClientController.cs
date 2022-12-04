using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Client;

[ApiExplorerSettings(GroupName = "client")]
[Route("client/[controller]/[action]")]
public class BaseClientController : BaseController
{
}