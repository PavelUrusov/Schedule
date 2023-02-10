using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "User")]
public class WorkSchemaController : ControllerBase
{
    private readonly IWorkSchemaService _wsService;

    public WorkSchemaController(IWorkSchemaService wsService)
    {
        _wsService = wsService;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RequestAddWorkSchemaDto request)
    {
        var response = await _wsService.AddWorkSchemaAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _wsService.GetListWorkSchemaAsync(this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] RequestRemoveWorkSchemaDto request)
    {
        var response = await _wsService.DeleteWorkSchemaAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}