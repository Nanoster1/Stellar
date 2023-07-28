using Microsoft.AspNetCore.Mvc;

using Stellar.IS.WebApi.Controllers.Common;

namespace Stellar.IS.WebApi.Controllers;

[Route("test")]
public class TestController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
    }
}