
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorTestController : Controller
{
    // [Route("test-503")]
    [HttpGet("test-503")]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public IActionResult Test503()
    {
        Response.StatusCode = 503;
        return View("503");
    }

    // [Route("PageNotFound")]
    [HttpGet("PageNotFound")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Test404()
    {
        Response.StatusCode = 404;
        return View("404");
    }
}