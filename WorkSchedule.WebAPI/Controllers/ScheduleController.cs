using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Authorize(Policy = "User")]
[Route("api/[controller]")]
[ApiController]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleManager _scheduleManager;

    public ScheduleController(IScheduleManager scheduleManager)
    {
        _scheduleManager = scheduleManager;
    }
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> AddSchedule(RequestAddScheduleDto request)
    {
        var response = await _scheduleManager.AddScheduleAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}