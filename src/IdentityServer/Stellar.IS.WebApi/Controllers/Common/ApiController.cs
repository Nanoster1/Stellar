using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Stellar.IS.WebApi.Controllers.Common;

[Authorize]
[ApiController]
public abstract class ApiController : ControllerBase
{
}