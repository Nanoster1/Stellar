using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Stellar.IS.Contracts.Routes.WebApi;
using Stellar.IS.WebApi.Controllers.Common;

namespace Stellar.IS.WebApi.Controllers;

[Route(WebApiRoutes.Controllers.ErrorController)]
public class ErrorController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Error()
    {
        return Problem();
    }
}