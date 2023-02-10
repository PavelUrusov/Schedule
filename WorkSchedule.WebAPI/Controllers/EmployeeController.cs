using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Authorize("User")]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeManager _employeeManager;

    public EmployeeController(IEmployeeManager employeeManager)
    {
        _employeeManager = employeeManager;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Add([FromBody] RequestAddEmployeeDto request)
    {
        var response = await _employeeManager.AddEmployeeAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddList([FromBody] RequestAddListEmployeeDto request)
    {
        var response = await _employeeManager.AddEmployeeListAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Remove([FromBody] RequestRemoveEmployeeDto request)
    {
        var response = await _employeeManager.RemoveEmployeeAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> RemoveList([FromBody] RequestRemoveListEmployeeDto request)
    {
        var response = await _employeeManager.RemoveListEmployeeAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}