using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "User")]
public class WorkMonthController : ControllerBase
{
    private readonly IWorkMonthService _service;

    public WorkMonthController(IWorkMonthService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Add(RequestAddWorkMonthDto request)
    {
        var response = await _service.AddWorkMonthAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] RequestGetRangeWorkMonthDto request)
    {
        var response = await _service.FindRangeWorkMonthAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}