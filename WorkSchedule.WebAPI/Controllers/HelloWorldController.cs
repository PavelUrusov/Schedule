using Microsoft.AspNetCore.Mvc;

namespace WorkSchedule.WebAPI.Controllers;

[Route("WorkScheduleAPI/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    [Route("[action]")]
    [HttpGet]
    public IActionResult HelloWorld()
    {
        return StatusCode(200, "Hello World!");
    }
}