using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "admin")]
[Route("admin/[controller]/[action]")]
public class BaseAdminController : BaseController
{
}