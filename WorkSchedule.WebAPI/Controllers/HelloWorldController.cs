using Microsoft.AspNetCore.Mvc;

namespace WorkSchedule.WebAPI.Controllers;

[Route("WorkScheduleAPI")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    [Route("[action]")]
    [HttpGet]
    public IActionResult Hi()
    {
        return StatusCode(200, "Hello World!");
    }
}