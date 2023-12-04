using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using DVP.Project.Api.SeedWork;

namespace DVP.Project.Api.Controllers;

[ApiController]
[Route("api/dvp/" + "[Controller]")]
public class DVPController : ControllerBase
{
    private const int OkCode = 200;
    private const int BadRequestCode = 400;
    private const int UnauthorizedCode = 401;
    private const int PaymentRequiredCode = 402;
    private const int ForbiddenCode = 403;
    private const int NotFoundCode = 404;

    protected Task<IActionResult> SuccessResquest(object data)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        var response = new ResponseData()
        {
            Code = OkCode,
            Status = true,
            Message = "",
            Data = JsonSerializer.SerializeToNode(data, options)
        };
        return Task.FromResult<IActionResult>(Ok(response));
    }

    protected Task<IActionResult> UnSuccessRequest(object message)
    {
        var response = new ResponseData()
        {
            Code = BadRequestCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(BadRequest(response));
    }

    protected Task<IActionResult> UnSuccessRequestNotFound(object message)
    {
        var response = new ResponseData()
        {
            Code = NotFoundCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(NotFound(response));
    }

    protected Task<IActionResult> UnexpectedErrorResquest(object message)
    {
        var response = new ResponseData()
        {
            Code = BadRequestCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(BadRequest(response));
    }
}
