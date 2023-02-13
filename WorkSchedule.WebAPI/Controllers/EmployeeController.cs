using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;
using WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

namespace WorkSchedule.WebAPI.Controllers;

[Authorize(Policy = "User")]
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


    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetList([FromQuery] RequestGetWorkObjectDto request)
    {
        var response = await _employeeManager.GetListEmployeeAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Get([FromQuery] RequestGetEmployeeDto request)
    {
        var response = await _employeeManager.FindEmployeeAsync(request, this.UserId()!.Value);

        return StatusCode(response.StatusCode, response);
    }
}