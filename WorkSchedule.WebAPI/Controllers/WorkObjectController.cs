using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Authorize(Policy = "User")]
[Route("api/[controller]")]
[ApiController]
public class WorkObjectController : ControllerBase
{
    private readonly IWorkObjectService _woService;

    public WorkObjectController(IWorkObjectService woService)
    {
        _woService = woService;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RequestAddWorkObjectDto request)
    {
        var response = await _woService.AddWorkObject(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _woService.GetListWorkObjectAsync(this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] RequestGetWorkObjectDto dto)
    {
        var response = await _woService.GetWorkObjectAsync(dto, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] RequestRemoveWorkObjectDto dto)
    {
        var response = await _woService.RemoveWorkObjectAsync(dto, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> AddWorkMonth([FromBody] RequestAddWorkMonthDto dto)
    {
        var response = await _woService.AddWorkMonth(dto, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}