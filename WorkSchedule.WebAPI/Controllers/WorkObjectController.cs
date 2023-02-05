using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObject;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;
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
    public async Task<IActionResult> Add([FromBody] AddWorkObjectDto request)
    {
        var response = await _woService.AddWorkObject(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _woService.GetAllWorkObjectsAsync(this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] WorkObjectIdDto dto)
    {
        var response = await _woService.GetWorkObjectAsync(dto, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] WorkObjectIdDto dto)
    {
        var response = await _woService.RemoveWorkObjectAsync(dto, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}